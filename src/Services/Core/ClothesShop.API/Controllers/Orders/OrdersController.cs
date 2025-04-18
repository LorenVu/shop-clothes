using BuildingBlock.Shared.Seeds;
using Clothes.Application.Features.Queries.Transactions.GetSepayTransactions;
using ClothesShop.API.Controllers.Configs;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClothesShop.API.Controllers.Orders;

[Microsoft.AspNetCore.Components.Route("api/v1/[controller]")]
public class OrdersController(IMediator mediator) : BaseController
{
    [HttpPost()]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Get sepay transactions")]
    public async Task<IActionResult> CreateOrder([FromBody] GetSepayTransactionsQuery query, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)    
            return BadRequest();

        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}