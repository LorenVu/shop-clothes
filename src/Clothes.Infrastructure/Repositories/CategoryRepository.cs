using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories;

public sealed class CategoryRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : RepositoryBase<Category, long>(context, unitOfWork), ICategoryRepository
{
    public Task<IQueryable<Category>> GetCategoriesPagination() =>
        Task.FromResult(GetAllAsync());

    public Task<Category> GetCategoryById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<long> CreateCategory(Category category) =>
        AddAsync(category);

    public Task UpDateCategory(Category category) =>
        UpdateAsync(category);

    public Task DeleteCategory(Category category) =>
        DeleteAsync(category);

}