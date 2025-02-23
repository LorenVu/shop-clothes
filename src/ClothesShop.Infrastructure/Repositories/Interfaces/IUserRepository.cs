using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBaseAsync<User, Guid, ApplicationDbContext>
{
    Task<IQueryable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
}