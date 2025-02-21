using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBaseAsync<SepayTransaction, int, ApplicationDbContext>
{
    Task<SepayTransaction?> GetSepayTransactionByIdAsync(int id, CancellationToken token = default);
    Task<int> CreateTransactionAsync(SepayTransaction entity);
    Task<List<int>> CreateTransactionsAsync(IEnumerable<SepayTransaction> entities);
    Task UpdateTransactionAsync(SepayTransaction entity);
    Task DeleteTransactionAsync(SepayTransaction entity);
}