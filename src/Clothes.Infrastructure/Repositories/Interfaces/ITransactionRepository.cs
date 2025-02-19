using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBase<Transaction, int>
{
    Task<IEnumerable<Transaction>> GetTransactionsAsync(string url, CancellationToken token = default);
    Task<Transaction?> GetTransactionByIdAsync(int id, CancellationToken token = default);
    Task<int> CreateTransactionAsync(Transaction entity);
    Task<List<int>> CreateTransactionsAsync(IEnumerable<Transaction> entities);
    Task UpdateTransactionAsync(Transaction entity);
    Task DeleteTransactionAsync(Transaction entity);
}