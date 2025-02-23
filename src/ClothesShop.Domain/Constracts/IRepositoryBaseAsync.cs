using System.Linq.Expressions;
using Clothes.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Domain.Constracts;

public interface IRepositoryQueryBaseAsync<TEntity, TK, TContext>
    where TEntity : EntityBase<TK>
    where TContext : DbContext
{
    IQueryable<TEntity> GetAllAsync(bool trackChanges = false);
    IQueryable<TEntity> GetAllAsync(bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties);
    IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false);
    IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> FindByIdAsync(TK id);
    Task<TEntity?> FindByIdAsync(TK id, params Expression<Func<TEntity, object>>[] includeProperties);
}

public interface IRepositoryBaseAsync<TEntity, TK, TContext> : IRepositoryQueryBaseAsync<TEntity, TK, TContext>
    where TEntity : EntityBase<TK>
    where TContext : DbContext
{
    Task<TK> AddAsync(TEntity entity);
    Task<List<TK>> AddManyAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateManyAsync(IEnumerable<TEntity> entities);
    Task DeleteAsync(TEntity entity);
    Task DeleteManyAsync(IEnumerable<TEntity> entities);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}