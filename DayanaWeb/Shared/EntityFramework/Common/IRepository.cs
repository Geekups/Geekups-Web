using System.Linq.Expressions;
namespace DayanaWeb.Shared.EntityFramework.Common;


public interface IRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<bool> ExistsAsync(int id);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);

    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
}
