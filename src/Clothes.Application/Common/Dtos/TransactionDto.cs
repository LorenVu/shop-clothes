namespace Clothes.Application.Common.Dtos;

public class TransactionDto
{
    public string AccountNumber { get; private set; } = string.Empty;
    public string SubAccount { get; private set; } = string.Empty;
    public string TransactionContent { get; private set; } = string.Empty;
    public string? Balance { get; private set; }
    public string ReferenceNumber { get; private set; } = string.Empty;
    public string BankBrandName { get; private set; } = string.Empty;
    public string? AmountIn { get; private set; }
    public string? AmountOut { get; private set; }
    public string? Accumulated { get; private set; }
}