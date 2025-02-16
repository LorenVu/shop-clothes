using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Constracts;
using MinimalApi.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity, TK>(ApplicationDbContext context, IUnitOfWork unitOfWork)
    : IRepositoryBase<TEntity, TK>
    where TEntity : EntityBase<TK>
{
    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false) =>
        trackChanges
            ? context.Set<TEntity>()
            : context.Set<TEntity>().AsNoTracking();

    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false, params Expression<Func<TEntity, TK>>[] includeProperties)
    {
        var entities = trackChanges 
            ? context.Set<TEntity>() 
            : context.Set<TEntity>().AsNoTracking();
        
        var aggregate = includeProperties.Aggregate(entities, (current, includeProperty) 
            => current.Include(includeProperty));
        
        return aggregate;
    }

    public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false) =>
         GetAllAsync(trackChanges).Where(predicate);

    public IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate, bool trackChanges = false, params Expression<Func<TEntity, bool>>[] includeProperties)
    {
        var entities = GetAllAsync(trackChanges).Where(predicate);
        var aggregate = includeProperties.Aggregate(entities, (current, includeProperty) 
            => current.Include(includeProperty));
        
        return aggregate;
    }

    public Task<TEntity?> FindByIdAsync(TK id) =>
        FindByConditionAsync(x => x.Id != null && x.Id.Equals(id), true).FirstOrDefaultAsync();

    public Task<TEntity?> FindByIdAsync(TK id, params Expression<Func<TEntity, bool>>[] includeProperties) => 
        FindByConditionAsync(x => x.Id != null && x.Id.Equals(id), false, includeProperties).FirstOrDefaultAsync();

    public async Task<TK> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity.Id;
    }

    public async Task<List<TK>> AddManyAsync(IEnumerable<TEntity> entities)
    {
        await context.Set<TEntity>().AddRangeAsync(entities);
        return entities.Select(x => x.Id).ToList();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateManyAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
        
    public Task DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        context.Set<TEntity>().RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync() =>
        await unitOfWork.SaveChangesAsync();
    
}