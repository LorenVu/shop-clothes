using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Commnon;
using MinimalApi.Domain.Constracts;
using MinimalProject.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity, K>(ApplicationDbContext context, IUnitOfWork unitOfWork)
    : IRepositoryBase<TEntity, K>
    where TEntity : EntityBase<K>
{
    protected ApplicationDbContext _context = context;
    protected IUnitOfWork _unitOfWork = unitOfWork;

    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false) =>
        trackChanges
            ? _context.Set<TEntity>()
            : _context.Set<TEntity>().AsNoTracking();

    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false, params Expression<Func<TEntity, K>>[] includeProperties)
    {
        var entities = trackChanges 
            ? _context.Set<TEntity>() 
            : _context.Set<TEntity>().AsNoTracking();
        
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

    public Task<TEntity?> FindByIdAsync(K id) =>
        FindByConditionAsync(x => x.Id.Equals(id), true).FirstOrDefaultAsync();

    public Task<TEntity?> FindByIdAsync(K id, params Expression<Func<TEntity, bool>>[] includeProperties) => 
        FindByConditionAsync(x => x.Id.Equals(id), false, includeProperties).FirstOrDefaultAsync();

    public async Task<K> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity.Id;
    }

    public async Task<List<K>> CreateManyAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
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
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
        
    public Task DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync() =>
        await _unitOfWork.SaveChangesAsync();
    
}