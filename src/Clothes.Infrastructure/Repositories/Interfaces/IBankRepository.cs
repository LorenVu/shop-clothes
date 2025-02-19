using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface IBankRepository : IRepositoryBase<Bank, int>
{
    Task<IEnumerable<Bank>> GetBanksAsync();
    Task<Bank?> GetBankByIdAsync(int id);
    Task<int> CreateBankAsync(Bank entity);
    Task UpdateBankAsync(Bank entity);
    Task DeleteBankAsync(Bank entity);
}