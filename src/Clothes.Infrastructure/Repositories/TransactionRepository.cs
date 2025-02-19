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
    ) : RepositoryBase<Transaction, int>(context, unitOfWork), ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> GetTransactionsAsync(string url, CancellationToken token = default)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {sepayConfig.ApiToken}");
        var response = await httpClient.GetAsync(url, cancellationToken: token);

        var result = await response.Content.ReadFromJsonAsync<SepayTransactionResponse>(cancellationToken: token);
        return result.Transactions;
    }

    public async Task<Transaction?> GetTransactionByIdAsync(int id, CancellationToken token = default) =>
        await FindByIdAsync(id);

    public Task<int> CreateTransactionAsync(Transaction entity) =>
        AddAsync(entity);

    public Task<List<int>> CreateTransactionsAsync(IEnumerable<Transaction> entities) =>
        AddManyAsync(entities);

    public Task UpdateTransactionAsync(Transaction entity) =>
        UpdateAsync(entity);

    public Task DeleteTransactionAsync(Transaction entity) =>
        DeleteAsync(entity);

}