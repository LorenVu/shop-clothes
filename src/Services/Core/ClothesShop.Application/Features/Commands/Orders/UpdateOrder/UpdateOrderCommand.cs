namespace Clothes.Application.Features.Commands.Orders.UpdateOrder;

public class UpdateOrderCommand : CreateOrUpdateOrderCommand
{
    public long Id { get; set; }
    public string? CancelReason { get; init; }
}