using Basket.API.Entities;
using BuildingBlock.Shared.Seeds;

namespace Basket.API.Services;

public interface IBasketService
{
    Task<Cart> GetCartAsync(Guid customerId);
    Task<ApiResult<object>> AddItemToCartAsync(Guid customerId, CartItem item);
    Task<ApiResult<object>> RemoveItemToCartAsync(Guid customerId, CartItem item);
    Task CheckoutAsync(Guid customerId);
}