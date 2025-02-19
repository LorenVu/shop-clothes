using System.Text.Json.Serialization;

namespace Clothes.Infrastructure.Shared.Requests;

public class OrderCondition
{
    public string? Field { get; set; }
    public string? Direction { get; set; } // "asc" or "desc"
}