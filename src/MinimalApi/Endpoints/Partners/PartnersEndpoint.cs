using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features;

namespace MinimalProject.Endpoints.Partners;

public class PartnersEndpoint : IEndpoint
{
    public string Group => nameof(PartnersEndpoint).Split("Endpoint").First().ToLower();
    public string Version => "api/v1";
    
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/pagination", async (IMediator mediator, [FromBody] GetCustomersPaginationQuery query) =>
        {
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }).WithOpenApi();
    }


}