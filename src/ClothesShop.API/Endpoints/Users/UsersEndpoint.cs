using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features;
using MinimalApi.Application.Features.Commands.Users;
using MinimalApi.Application.Features.Queries.Users;

namespace MinimalProject.Endpoints.Users;

public class UsersEndpoint : IEndpoint
{
    public string Group => nameof(UsersEndpoint).Split("Endpoint").First().ToLower();
    public string Version => "api/v1";
    
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/pagination", async (IMediator mediator, [FromBody] GetCustomersPaginationQuery query) =>
        {
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }).WithOpenApi();
        
        routeBuilder.MapPost("/", async (IMediator mediator, [FromBody] CreateUserCommand command) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }).WithOpenApi();
        
        routeBuilder.MapGet("/{id:guid}", async (IMediator mediator, [FromRoute] Guid id) =>
        {
            var query = new GetUserByIdQuery
            {
                Id = id
            };

            var result = await mediator.Send(query);
            
            return Results.Ok(result);
        }).WithOpenApi();
    }
}