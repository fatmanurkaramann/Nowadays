using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract;

namespace DataAccess.UoW
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        IRepository<T> GetRepository<T>() where T : BaseEntity, new();
        IEmployeeDal Employees { get; }
        IProjectDal Projects { get; }
        IIssueDal Issues { get; }
        ICompanyDal Companies { get; }
    }
}
