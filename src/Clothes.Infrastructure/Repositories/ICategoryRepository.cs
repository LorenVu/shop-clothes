using System.Linq.Expressions;
using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Repositories;

public interface ICategoryRepository : IRepositoryBase<Category, long>
{
    Task<IQueryable<Category>> GetCategoriesPagination(params Expression<Func<Category, long>>[] expression);
    Task<Category?> GetCategoryById(long id);
    Task<long> CreateCategory(Category category);
    Task UpDateCategory(Category category);
    Task DeleteCategory(Category category);
}