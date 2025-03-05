using System.Linq.Expressions;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;

namespace Clothes.Infrastructure.Repositories;

public sealed class CategoryRepository(ApplicationDbContext context, IUnitOfWork<ApplicationDbContext> unitOfWork)
    : RepositoryBaseAsync<Category, long, ApplicationDbContext>(context, unitOfWork), ICategoryRepository
{
    public Task<IQueryable<Category>> GetCategoriesPaginationAsync(params Expression<Func<Category, object>>[] includeProperties) =>
        Task.FromResult(GetAllAsync(false, includeProperties));

    public Task<Category?> GetCategoryByIdAsync(long id) =>
        FindByIdAsync(id);
}