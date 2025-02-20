using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBase<SepayTransaction, int>
{
    Task<IEnumerable<SepayTransaction>> GetTransactionsAsync(string url, CancellationToken token = default);
    Task<SepayTransaction?> GetTransactionByIdAsync(int id, CancellationToken token = default);
    Task<int> CreateTransactionAsync(SepayTransaction entity);
    Task<List<int>> CreateTransactionsAsync(IEnumerable<SepayTransaction> entities);
    Task UpdateTransactionAsync(SepayTransaction entity);
    Task DeleteTransactionAsync(SepayTransaction entity);
}