using Clothes.Application.Features.Queries.Transactions.GetSepayTransactions;
using Clothes.Infrastructure.Shared.Responses;
using ClothesShop.API.Controllers.Configs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClothesShop.API.Controllers.Transactions;

[Route("api/v1/[controller]")]
public class TransactionsController(IMediator mediator) : BaseController
{
    [HttpPost("paginations")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Get sepay transactions")]
    public async Task<IActionResult> GetSepayTransactions([FromBody] GetSepayTransactionsQuery query,
        [FromServices] IValidator<GetSepayTransactionsQuery> validator, CancellationToken cancellationToken
    )
    {
        if (!ModelState.IsValid) 
            return BadRequest();

        await validator.ValidateAndThrowAsync(query, cancellationToken);
        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
}