using System.Text.Json.Serialization;
using Clothes.Domain.Entities;

namespace Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;

public class SepayTransactionResponse : SepayBaseResponse<SepayTransaction>
{
    [JsonPropertyName("transactions")]
    public HashSet<SepayTransaction> Transactions { get; set; } = [];
}