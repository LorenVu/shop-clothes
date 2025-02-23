using System.Runtime.InteropServices.ComTypes;
using Clothes.Application.Common.Dtos;
using Clothes.Application.Features.Commands.Users.CreateUser;
using Clothes.Application.Features.Commands.Users.DeleteUser;
using Clothes.Application.Features.Commands.Users.UpdateUser;
using Clothes.Application.Features.Queries.Users.GetCustomers;
using Clothes.Application.Features.Queries.Users.GetUserById;
using Clothes.Infrastructure.Seeds;
using Clothes.Infrastructure.Shared.Responses;
using ClothesShop.API.Controllers.Configs;
using MediatR;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClothesShop.API.Controllers.Users;

[Route("/api/v1/[controller]")]
public class UsersController(IMediator mediator) : BaseController
{
    [HttpPost("pagination")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Create user")]    
    public async Task<IActionResult> GetUsersPagination([FromBody] GetUsersPaginationQuery query)
    {
        var result = await mediator.Send(query);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Create user")]    
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationtoken)
    {
        var query = new GetUserByIdQuery(id);
        var result = await mediator.Send(query, cancellationtoken);

        return Ok(result);
    }

    [HttpPost]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Create user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpPut("{id:guid}")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Update user")]
    public async Task<IActionResult> UpdateUser([FromRoute]Guid id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
    {
        command.SetId(id);
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete("{id:guid}")]
    [RequestTimeout(CustomTimeoutProfileConfigs.Over15S)]
    [ResponseCache(CacheProfileName = CustomCacheProfile.NoCache)]
    [ProducesResponseType(typeof(ApiResult<>), 200)]
    [SwaggerOperation(summary: "Delete user")]
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}