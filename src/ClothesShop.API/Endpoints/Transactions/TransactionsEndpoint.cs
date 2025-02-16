using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application.Features.Queries;

namespace MinimalProject.Endpoints.Transactions;

public class TransactionsEndpoint : IEndpoint
{
    public string Group => nameof(TransactionsEndpoint).Split("Endpoint").First().ToLower();
    public string Version => "api/v1";

    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/pagination", async (IMediator mediator, [FromBody] GetTransactionQuery query) =>
        {
            var result = await mediator.Send(query);

            return Results.Ok(result);
        }).WithOpenApi();
    }
}