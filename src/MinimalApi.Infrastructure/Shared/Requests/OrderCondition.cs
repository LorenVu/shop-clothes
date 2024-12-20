using System.Text.Json.Serialization;

namespace MinimalApi.Infrastructure.Shared.Requests;

public class OrderCondition
{
    [JsonConstructor]
    protected OrderCondition(string? field, string? direction)
    {
        Field = field;
        Direction = direction;
    }

    public string? Field { get; set; }
    public string? Direction { get; set; } // "asc" or "desc"
}