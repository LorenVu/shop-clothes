using System.Linq.Expressions;
using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository : IRepositoryBaseAsync<Category, long, ApplicationDbContext>
{
    Task<IQueryable<Category>> GetCategoriesPaginationAsync(params Expression<Func<Category, object>>[] expression);
    Task<Category?> GetCategoryByIdAsync(long id);
}