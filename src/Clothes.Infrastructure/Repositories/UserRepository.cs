using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    public UserRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    public async Task<IEnumerable<User>> GetUsersAsync() =>
        await GetAllAsync().ToListAsync();

    public async Task<User?> GetUserByIdAsync(Guid id) =>
        await FindByIdAsync(id);

    public Task<User?> GetUserByEmailAsync(string email) =>
        FindByConditionAsync(u => u.EmailAddress == email).FirstOrDefaultAsync();

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