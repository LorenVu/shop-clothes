using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context, IUnitOfWork<ApplicationDbContext> unitOfWork)
    : RepositoryBaseAsync<User, Guid, ApplicationDbContext>(context, unitOfWork), IUserRepository
{
    public Task<IQueryable<User>> GetUsersAsync() =>
        Task.FromResult(GetAllAsync());

    public async Task<User?> GetUserByIdAsync(Guid id) =>
        await FindByIdAsync(id);

    public Task<User?> GetUserByEmailAsync(string email) =>
        FindByConditionAsync(u => u.EmailAddress == email).FirstOrDefaultAsync();
}