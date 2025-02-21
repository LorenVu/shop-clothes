using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface IBankRepository : IRepositoryBaseAsync<Bank, int, ApplicationDbContext>
{
    Task<IEnumerable<Bank>> GetBanksAsync();
    Task<Bank?> GetBankByIdAsync(int id);
    Task<int> CreateBankAsync(Bank entity);
    Task UpdateBankAsync(Bank entity);
    Task DeleteBankAsync(Bank entity);
}