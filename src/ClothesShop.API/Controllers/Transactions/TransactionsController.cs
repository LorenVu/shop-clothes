using Clothes.Application.Features.Queries.Transactions.GetTransactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.API.Controllers.Transactions;

[Microsoft.AspNetCore.Components.Route("api/v1/[controller]")]
public class TransactionsController(IMediator mediator) : BaseController
{
    [HttpGet("paginations")]
    public async Task<IActionResult> GetTransactions([FromQuery] GetTransactionsQuery query)
    {
        if (!ModelState.IsValid) 
            return BadRequest();
        
        var transactions = await mediator.Send(query);
        return Ok(transactions);
    }
}