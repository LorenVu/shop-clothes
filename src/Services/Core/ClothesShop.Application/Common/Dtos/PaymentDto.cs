namespace Clothes.Application.Common.Dtos;

public class PaymentDto
{
    public double Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? PaymentCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public double Fee { get; set; }
    public int Status { get; set; }
    public bool IsDeleted { get; set; }
    public int OrderId { get; set; }
}