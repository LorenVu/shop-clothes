using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Persistences;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalApi.Infrastructure.Repositories;

public class BankRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) 
    : RepositoryBase<Bank, int>(context, unitOfWork),IBankRepository
{
    public async Task<IEnumerable<Bank>> GetBanksAsync()
        => await GetAllAsync().ToListAsync();

    public async Task<Bank?> GetBankByIdAsync(int id)
        => await FindByIdAsync(id);
    
    public Task<int> CreateBankAsync(Bank entity) => 
        AddAsync(entity);
    
    public Task UpdateBankAsync(Bank entity) => 
        UpdateAsync(entity);
    
    public Task DeleteBankAsync(Bank entity) =>
        DeleteAsync(entity);
}