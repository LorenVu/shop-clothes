using System.Text.Json.Serialization;

namespace MinimalApi.Infrastructure.Shared.Requests;

public class OrderCondition
{
    public string? Field { get; set; }
    public string? Direction { get; set; } // "asc" or "desc"
}