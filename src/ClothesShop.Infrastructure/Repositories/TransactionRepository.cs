using System.Net.Http.Json;
using Clothes.Domain.Configs;
using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;

namespace Clothes.Infrastructure.Repositories;

public class TransactionRepository(
    ApplicationDbContext context,
    IUnitOfWork<ApplicationDbContext> unitOfWork
    ) : RepositoryBaseAsync<SepayTransaction, int, ApplicationDbContext>(context, unitOfWork), ITransactionRepository
{
    public async Task<SepayTransaction?> GetSepayTransactionByIdAsync(int id, CancellationToken token = default) =>
        await FindByIdAsync(id);

    public Task<List<int>> CreateTransactionsAsync(IEnumerable<SepayTransaction> entities) =>
        AddManyAsync(entities);
}