using System.Net.Http.Json;
using BuildingBlock.Shared.Configs;
using Clothes.Application.Services.Interfaces;
using Clothes.Domain.Entities;
using Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;

namespace Clothes.Application.Services.Transactions;

public class SepayTransactionService(HttpClient httpClient,
    SepayConfigs sepayConfigs) : ISepayTransactionService
{
    public async Task<IEnumerable<SepayTransaction>?> GetTransactionsAsync(string url, CancellationToken token = default)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {sepayConfigs.ApiToken}");
        var response = await httpClient.GetAsync(url, cancellationToken: token);

        var result = await response.Content.ReadFromJsonAsync<SepayTransactionResponse>(cancellationToken: token);
        return result?.Transactions;
    }

    public Task<SepayTransaction?> GetTransactionByIdAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}