namespace MinimalApi.Domain.ValueObjects;

public record FilterOperators (string Operator)
{
    public static FilterOperators Equal { get; } = new("equals");
    public static FilterOperators NotEquals { get; } = new("notEquals");
    public static FilterOperators GreaterThan { get; } = new("greaterThan");
    public static FilterOperators GreaterThanOrEqual { get; } = new("greaterThanOrEqual");
    public static FilterOperators LessThan { get; } = new("lessThan");
    public static FilterOperators LessThanOrEqual { get; } = new("lessThanOrEqual");
    public static FilterOperators Contains { get; } = new("contains");
}