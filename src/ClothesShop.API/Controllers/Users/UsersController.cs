using Clothes.Application.Common.Dtos;
using Clothes.Application.Features.Queries.Users.GetCustomers;
using Clothes.Application.Features.Queries.Users.GetUserById;
using Clothes.Infrastructure.Seeds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.API.Controllers.Users;

[Route("/api/v1/[controller]")]
public class UsersController(IMediator mediator) : BaseController
{
    private static class RouteNames
    {
        public const string GetUsersPagination = nameof(GetUsersPagination);
    }
    
    [HttpGet("pagination")]
    [ProducesResponseType(typeof(PagedList<UserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsersPagination([FromQuery] GetUsersPaginationQuery query)
    {
        var result = await mediator.Send(query);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await mediator.Send(query);

        return Ok(result);
    }
}