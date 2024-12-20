using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features;
using MinimalApi.Application.Features.Commands.CreateCustomer;
using MinimalApi.Application.Features.Queries.GetUserById;

namespace MinimalProject.Endpoints.Users;

public class UsersEndpoint : IEndpoint
{
    public string Group => nameof(UsersEndpoint).Split("Endpoint").First();
    public string Version => "api/v1";
    
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/pagination", async (IMediator mediator, [FromBody] GetCustomersPaginationQuery query) =>
        {
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }).WithOpenApi();
        
        routeBuilder.MapPost("/", async (IMediator mediator, [FromBody] CreateCustomerCommand command) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }).WithOpenApi();
        
        routeBuilder.MapGet("/{id:long}", async (IMediator mediator, [FromRoute] long id) =>
        {
            var query = new GetCustomerByIdQuery
            {
                Id = id
            };

            var result = await mediator.Send(query);
            
            return Results.Ok(result);
        }).WithOpenApi();
    }
}