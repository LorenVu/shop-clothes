using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features;

namespace MinimalProject.Endpoints.Users;

public class GetUsers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("api/v1/users/pagination", async (IMediator mediator, [FromBody] GetCustomersPaginationQuery query) =>
        {
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }).WithOpenApi();
    }
}