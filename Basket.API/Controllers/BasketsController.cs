using Basket.API.Entities;
using Basket.API.Services;
using BuildingBlock.Shared.Seeds;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketsController(IBasketService basketService) : ControllerBase
{
    [HttpGet("{customerId:guid}")]
    [ProducesResponseType<ApiResult<Cart>>(200)]
    [SwaggerOperation(Summary = "Get cart by customer id")]
    public async Task<IActionResult> GetCart(Guid customerId)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = await basketService.GetCartAsync(customerId);
        return Ok(ApiSuccessResult<Cart>.Instance.WithMessage().WithData(result));
    }
    
    [HttpPost("{customerId:guid}")]
    [ProducesResponseType<ApiResult<Cart>>(200)]
    [SwaggerOperation(Summary = "Add item to cart")]
    public async Task<IActionResult> UpdateCart(Guid customerId, [FromBody] CartItem item)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = await basketService.AddItemToCartAsync(customerId, item);
        return Ok(result);
    }
    
    [HttpPut("{customerId:guid}")]
    [ProducesResponseType<ApiResult<Cart>>(200)]
    [SwaggerOperation(Summary = "Remove item to cart")]
    public async Task<IActionResult> ClearCart(Guid customerId, [FromBody] CartItem item)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        var result = await basketService.RemoveItemToCartAsync(customerId, item);
        return Ok(result);
    }
    
    [HttpPost("{customerId:guid}/checkout")]
    [ProducesResponseType<ApiResult<object>>(200)]
    [SwaggerOperation(Summary = "Checkout cart")]
    public async Task<IActionResult> Checkout(Guid customerId)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        await basketService.CheckoutAsync(customerId);
        return Ok(ApiSuccessResult<object>.Instance.WithMessage());
    }
}