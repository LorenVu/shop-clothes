using Basket.API.Entities;

namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<Cart> GetCartAsync(Guid customerId);
    Task<Cart> UpdateCartAsync(Guid customerId, Cart cart);
}