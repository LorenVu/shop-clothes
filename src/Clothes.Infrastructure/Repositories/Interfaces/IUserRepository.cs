using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBase<User, Guid>
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}