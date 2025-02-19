using System.Text.Json.Serialization;

namespace Clothes.Infrastructure.Shared.Responses.ExternalApiResponse.Sepay;

public abstract class SepayBaseResponse<T>
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }

    [JsonPropertyName("message")]
    public SepayMessage Message { get; set; }
}

public class SepayMessage
{
    public bool Success { get; set; }
}