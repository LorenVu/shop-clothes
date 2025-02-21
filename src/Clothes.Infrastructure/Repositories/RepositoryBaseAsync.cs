using System.Linq.Expressions;
using Clothes.Domain.Common;
using Clothes.Domain.Constracts;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Repositories;

public class RepositoryBaseAsync<TEntity, TK, TContext>
    : IRepositoryBaseAsync<TEntity, TK, TContext>
    where TEntity : EntityBase<TK>
    where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly IUnitOfWork<TContext> _unitOfWork;

    public RepositoryBaseAsync(TContext context, IUnitOfWork<TContext> unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        
        _dbContext = context;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false) =>
        trackChanges
            ? _dbContext.Set<TEntity>()
            : _dbContext.Set<TEntity>().AsNoTracking();

    public IQueryable<TEntity> GetAllAsync(bool trackChanges = false, params Expression<Func<TEntity, TK>>[] includeProperties)
    {
        var entities = trackChanges
            ? _dbContext.Set<TEntity>()
            : _dbContext.Set<TEntity>().AsNoTracking();

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
        await _dbContext.Set<TEntity>().AddAsync(entity);
        return entity.Id;
    }

    public async Task<List<TK>> AddManyAsync(IEnumerable<TEntity> entities)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities);
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
        _dbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken) =>
        await _unitOfWork.CommitAsync(cancellationToken);

}