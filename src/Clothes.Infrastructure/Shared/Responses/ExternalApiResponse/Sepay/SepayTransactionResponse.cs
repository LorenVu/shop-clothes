using System.Text.Json.Serialization;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;

public class SepayTransactionResponse : SepayBaseResponse<Transaction>
{
    [JsonPropertyName("transactions")]
    public HashSet<Transaction> Transactions { get; set; } = [];
}