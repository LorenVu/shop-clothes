namespace Clothes.Application.Common.Dtos;

public class OrderItemDto
{
    public int Quantity { get; set; }
    public double Price { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int PromotionId { get; set; }
}