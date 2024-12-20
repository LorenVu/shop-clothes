using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features.Commands.CreateCustomer;
using MinimalProject.Apis;

namespace MinimalProject.Endpoints.Users;

public class CreateUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/v1/users", async (IMediator mediator, [FromBody] CreateCustomerCommand command) =>
        {
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }).WithOpenApi();
    }
}