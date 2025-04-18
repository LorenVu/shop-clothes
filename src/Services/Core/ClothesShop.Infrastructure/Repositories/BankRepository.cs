using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Infrastructure.Repositories;

public class BankRepository(ApplicationDbContext context, IUnitOfWork<ApplicationDbContext> unitOfWork)
    : RepositoryBaseAsync<Bank, int, ApplicationDbContext>(context, unitOfWork), IBankRepository
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