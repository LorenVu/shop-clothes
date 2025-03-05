using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;

namespace Clothes.Infrastructure.Repositories.Interfaces;

public interface ITransactionRepository : IRepositoryBaseAsync<SepayTransaction, int, ApplicationDbContext>
{
    Task<SepayTransaction?> GetSepayTransactionByIdAsync(int id, CancellationToken token = default);
    Task<List<int>> CreateTransactionsAsync(IEnumerable<SepayTransaction> entities);
}