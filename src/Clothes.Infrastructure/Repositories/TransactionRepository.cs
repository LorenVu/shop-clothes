using System.Net.Http.Json;
using Clothes.Domain.Configs;
using Clothes.Domain.Constracts;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;
using Microsoft.EntityFrameworkCore;
using static System.String;

namespace Clothes.Infrastructure.Repositories;

public class TransactionRepository(
    ApplicationDbContext context,
    IUnitOfWork unitOfWork,
    HttpClient httpClient,
    SepayConfig sepayConfig
    ) : RepositoryBase<SepayTransaction, int>(context, unitOfWork), ITransactionRepository
{
    public async Task<IEnumerable<SepayTransaction>> GetTransactionsAsync(string url, CancellationToken token = default)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {sepayConfig.ApiToken}");
        var response = await httpClient.GetAsync(url, cancellationToken: token);

        var result = await response.Content.ReadFromJsonAsync<SepayTransactionResponse>(cancellationToken: token);
        return result.Transactions;
    }

    public async Task<SepayTransaction?> GetTransactionByIdAsync(int id, CancellationToken token = default) =>
        await FindByIdAsync(id);

    public Task<int> CreateTransactionAsync(SepayTransaction entity) =>
        AddAsync(entity);

    public Task<List<int>> CreateTransactionsAsync(IEnumerable<SepayTransaction> entities) =>
        AddManyAsync(entities);

    public Task UpdateTransactionAsync(SepayTransaction entity) =>
        UpdateAsync(entity);

    public Task DeleteTransactionAsync(SepayTransaction entity) =>
        DeleteAsync(entity);

}