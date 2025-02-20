using System.Linq.Expressions;
using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories;

public sealed class CategoryRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : RepositoryBase<Category, long>(context, unitOfWork), ICategoryRepository
{
    public Task<IQueryable<Category>> GetCategoriesPagination(params Expression<Func<Category, long>>[] expression) =>
        Task.FromResult(GetAllAsync(false, expression));

    public Task<Category?> GetCategoryById(long id) =>
        FindByIdAsync(id);
    public Task<long> CreateCategory(Category category) =>
        AddAsync(category);

    public Task UpDateCategory(Category category) =>
        UpdateAsync(category);

    public Task DeleteCategory(Category category) =>
        DeleteAsync(category);

}