using System.Linq.Expressions;
using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository : IRepositoryBaseAsync<Category, long, ApplicationDbContext>
{
    Task<IQueryable<Category>> GetCategoriesPagination(params Expression<Func<Category, long>>[] expression);
    Task<Category?> GetCategoryById(long id);
    Task<long> CreateCategory(Category category);
    Task UpDateCategory(Category category);
    Task DeleteCategory(Category category);
}