using Clothes.Domain.Entities;

namespace Clothes.Application.Services.Interfaces;

public interface ISepayTransactionService
{
    Task<IEnumerable<SepayTransaction>?> GetTransactionsAsync(string url, CancellationToken token = default);
    Task<SepayTransaction?> GetTransactionByIdAsync(int id, CancellationToken token = default);
}