using System.Text.Json.Serialization;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Shared.ExternalApiResponse.Sepay;

public class SepayTransactionResponse : SepayBaseResponse<Transaction>
{
    [JsonPropertyName("transactions")] 
    public HashSet<Transaction> Transactions { get; set; } = [];
}