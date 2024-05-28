using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.UoW
{
    public class UnitOfWork(NowadaysDbContext context) : IUnitOfWork, IDisposable
    {
        public IEmployeeDal Employees { get { return new EmployeeDal(context); } }
        public IProjectDal Projects { get { return new ProjectDal(context); } }
        public IIssueDal Issues { get { return new IssueDal(context); } }
        public ICompanyDal Companies { get { return new CompanyDal(context); } }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity, new()
        {
            return new Repository<T, DbContext>(context);
        }

        public void Rollback()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => Rollback(),cancellationToken);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
