using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Persistences;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalApi.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public async Task<IEnumerable<User>> GetUsersAsync() =>
        await GetAllAsync().ToListAsync();

    public async Task<User?> GetUserByIdAsync(Guid id) =>
        await FindByIdAsync(id);

    public async Task<User> CreateUserAsync(User user)
    {
        await AddAsync(user);
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        await UpdateAsync(user);
        return user;
    }

    public Task DeleteUserAsync(User user) =>
        DeleteAsync(user);
}