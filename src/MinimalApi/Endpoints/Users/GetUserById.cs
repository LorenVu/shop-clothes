using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features.Queries.GetUserById;

namespace MinimalProject.Endpoints.Users;

public class GetUserById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("api/v1/users/{id:long}", async (IMediator mediator, [FromRoute] long id) =>
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