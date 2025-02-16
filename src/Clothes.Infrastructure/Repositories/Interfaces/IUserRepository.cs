using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBase<User, Guid>
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}