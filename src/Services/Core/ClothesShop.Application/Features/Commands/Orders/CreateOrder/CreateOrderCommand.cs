using Clothes.Application.Common.Mappings;
using Clothes.Domain.Entities;

namespace Clothes.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommand : CreateOrUpdateOrderCommand, IMapFrom<Order>
{
    
}