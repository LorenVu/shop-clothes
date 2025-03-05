using Basket.API.Entities;
using Basket.API.Repositories;
using BuildingBlock.Shared.Seeds;

namespace Basket.API.Services;

public class BasketService(IBasketRepository basketRepository) : IBasketService
{
    public Task<Cart> GetCartAsync(Guid customerId) =>
        basketRepository.GetCartAsync(customerId);
        
    public async Task<ApiResult<object>> AddItemToCartAsync(Guid customerId, CartItem item)
    {
        var cart = await basketRepository.GetCartAsync(customerId);
        cart.Items.Add(item);    
        
        await basketRepository.UpdateCartAsync(customerId, cart);
        return ApiSuccessResult<object>.Instance.WithMessage().WithData(cart);
    }

    public async Task<ApiResult<object>> RemoveItemToCartAsync(Guid customerId, CartItem item)
    {
        var cart = await basketRepository.GetCartAsync(customerId);
        cart.Items.Remove(item);    
        
        await basketRepository.UpdateCartAsync(customerId, cart);
        return ApiSuccessResult<object>.Instance.WithMessage().WithData(cart);
    }

    public Task CheckoutAsync(Guid customerId)
    {
        throw new NotImplementedException();
    }
}