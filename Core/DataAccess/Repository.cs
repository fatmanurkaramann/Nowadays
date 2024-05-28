using Core.Entities;
using Core.Exceptions;
using Core.Helpers;
using Core.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public class Repository<T, TContext>(TContext context) : IRepository<T> 
        where T : BaseEntity ,new()
        where TContext : DbContext
    {
        protected TContext Context { get; } = context;
        public DbSet<T> Table => Context.Set<T>();
      
        public async Task<OperationResult<T>> AddAsync(T entity,CancellationToken cancellationToken = default)
        {
            EntityEntry<T> entityEntry = await Context.AddAsync(entity,cancellationToken);

            return new OperationResult<T>(entity, entityEntry.State == EntityState.Added);
        }
        public async Task<OperationResult<T>> DeleteByPredicateAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken )
        {
            T? model = await GetAsync(predicate, cancellationToken: cancellationToken)
                ?? throw new NotFoundException($"Silmek istenilen {EntityNameTranslateHelper.Translate(typeof(T).Name)} bulunamadı.");

            return Delete(model);
        }

        public async Task<OperationResult<T>> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await DeleteByPredicateAsync(m => m.Id == id, cancellationToken);
        }

        public async Task<OperationResult<T>> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            EntityEntry<T> entityEntry = Context.Update(entity);
            return new OperationResult<T>(entity, entityEntry.State == EntityState.Modified);
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include is not null)
                queryable = include(queryable);
            if (predicate is not null)
                return await queryable.Where(predicate)
                    .ToListAsync(cancellationToken);

            return await queryable.ToListAsync(cancellationToken);
        }
        public async Task<T?> GetByIdAsync(int id, bool tracking = true)
        {
            return await GetAsync(c=>c.Id == id, enableTracking: tracking);
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                bool enableTracking = true,
                                                CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table;

            if (include is not null)
                queryable = include(queryable);
            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.SaveChangesAsync(cancellationToken);
        }

        private OperationResult<T> Delete(T entity)
        {
            EntityEntry<T> entityEntry = Context.Remove(entity);
            return new OperationResult<T>(entity, entityEntry.State == EntityState.Deleted);
        }

    }
}
