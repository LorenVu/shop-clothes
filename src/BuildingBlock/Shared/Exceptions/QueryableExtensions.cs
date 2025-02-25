using System.Linq.Expressions;

namespace Clothes.Domain.Extensions;

public static class QueryableExtensions
{
    /// <summary>
    /// Apply a filter to entity queryable 
    /// </summary>
    /// <param name="queryable">  </param>
    /// <param name="filterExpressions"></param>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <returns></returns>
    public static IQueryable<TEntity> ApplyFilter<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, bool>>[] filterExpressions)
        => filterExpressions.Aggregate(queryable, (current, expression) => current.Where(expression));
    
    /// <summary>
    /// Apply sorting to an IQueryable.
    /// </summary>
    /// <param name="queryable">The queryable source</param>
    /// <param name="orderByExpressions">Sorting expressions</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Sorted IQueryable</returns>
    public static IQueryable<TEntity> ApplyOrder<TEntity>(this IQueryable<TEntity> queryable, params Expression<Func<TEntity, bool>>[] orderByExpressions)
    {
        if (orderByExpressions.Length == 0)
            return queryable;

        IOrderedQueryable<TEntity> orderedQuery = queryable.OrderBy(orderByExpressions[0]);

        for (var i = 1; i < orderByExpressions.Length; i++)
        {
            orderedQuery = orderedQuery.ThenBy(orderByExpressions[i]);
        }

        return orderedQuery;
    }
}