using System.Linq.Expressions;
using MinimalApi.Domain.Commnon;

namespace MinimalApi.Domain.Constracts;

public interface IRepositoryQueryBase<TEntity, K>
    where TEntity : EntityBase<K>
{
    IQueryable<TEntity> GetAllAsync(bool trackChanges = false);
    IQueryable<TEntity> GetAllAsync(bool trackChanges = false, params Expression<Func<TEntity, K>>[] includeProperties);
    IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false);
    IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate , bool trackChanges = false, params Expression<Func<TEntity, bool>>[] includeProperties);
    Task<TEntity?> FindByIdAsync(K id);
    Task<TEntity?> FindByIdAsync(K id, params Expression<Func<TEntity, bool>>[] includeProperties);
}

public interface IRepositoryBase<TEntity, K> : IRepositoryQueryBase<TEntity, K>
    where TEntity : EntityBase<K>
{
    Task<K> AddAsync(TEntity entity);
    Task<List<K>> AddManyAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateManyAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteManyAsync(IEnumerable<TEntity> entities);
    Task<int> SaveChangesAsync();
}