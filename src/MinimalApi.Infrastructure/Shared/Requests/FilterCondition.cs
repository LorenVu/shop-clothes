using System.Text.Json.Serialization;

namespace MinimalApi.Infrastructure.Shared.Requests;

public class FilterCondition
{
    [JsonConstructor]
    protected FilterCondition(string? field, string? @operator, object? value)
    {
        Field = field;
        Operator = @operator;
        Value = value;
    }

    public string? Field { get; set; }
    public string? Operator { get; set; } // e.g., "equals", "greaterThan", etc.
    public object? Value { get; set; }
}