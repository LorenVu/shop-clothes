using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shared.Extensions;

namespace Basket.API.Repositories;

public class BasketRepository(IDistributedCache redisCache) : IBasketRepository
{
    public async Task<Cart> GetCartAsync(Guid customerId)
    {
        var cart = new Cart();
        var cartData = await redisCache.GetStringAsync(customerId.ToString());

        if (!string.IsNullOrWhiteSpace(cartData))
            UpdateCartAsync(customerId, cart);
            
        cartData!.TryParseJson<Cart>(out cart);
        return cart;
    }


    public Task<Cart> UpdateCartAsync(Guid customerId, Cart cart)
    {
        var cartJson = JsonConvert.SerializeObject(cart);
        redisCache.SetStringAsync(customerId.ToString(), cartJson);
        return Task.FromResult(cart);
    }
}