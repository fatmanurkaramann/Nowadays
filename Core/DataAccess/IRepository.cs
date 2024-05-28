using Core.Wrappers;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<OperationResult<T>> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> DeleteByPredicateAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                  bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
             bool enableTracking = true, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(int id, bool tracking = true);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
