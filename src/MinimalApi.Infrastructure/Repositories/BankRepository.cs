using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalProject.Infrastructure.Persistences;

namespace MinimalApi.Infrastructure.Repositories;

public class BankRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) 
    : RepositoryBase<Bank, int>(context, unitOfWork),IBankRepository
{
    public async Task<IEnumerable<Bank>> GetBanksAsync()
        => await GetAllAsync().ToListAsync();
    
}