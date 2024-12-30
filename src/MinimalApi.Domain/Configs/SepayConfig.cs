namespace MinimalApi.Domain.Configs;

public class SepayConfig
{
    public string? ApiToken { get; init; }
    public string? BaseUrl { get; init; }
    public SePayEndpoint BankAccountEndpoints { get; init; } = new();
    public SePayEndpoint TransactionEndpoints { get; init; } = new();
}

public class SePayEndpoint
{
    public string? BaseEndpoint { get; init; }
    public string? List { get; init; }
    public string? Details { get; init; }
    public string? Count { get; init; }
}