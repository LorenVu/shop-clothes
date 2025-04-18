using System.Text.Json.Serialization;
using Clothes.Application.Common.Dtos;

namespace Clothes.Application.Features.Commands.Orders;

public class CreateOrUpdateOrderCommand
{
    public string? Name { get; init; }
    public string? CustomerName { get; init; }
    public string? Address { get; init; }
    public string? PhoneNumber { get; init; }
    [JsonIgnore]
    public double TotalAmount { get; init; }
    public string? Note { get; init; }
    public Guid? CustomerId { get; init; }
    public int OrderStatusId { get; set; }

    public virtual ICollection<PaymentDto>? Payments { get; init; }
    public virtual ICollection<OrderItemDto>? Items { get; init; }
}