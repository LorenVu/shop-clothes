using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Configs;
using MinimalApi.Domain.Constracts;
using MinimalApi.Domain.Entities;
using MinimalApi.Infrastructure.Persistences;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Shared.ExternalApiResponse.Sepay;
using static System.String;

namespace MinimalApi.Infrastructure.Repositories;

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
        CreateAsync(entity);
    
    public Task<List<int>> CreateTransactionsAsync(IEnumerable<Transaction> entities) =>
        CreateManyAsync(entities);

    public Task UpdateTransactionAsync(Transaction entity) =>
        UpdateAsync(entity);
    
    public Task DeleteTransactionAsync(Transaction entity) =>
        DeleteAsync(entity);
    
}