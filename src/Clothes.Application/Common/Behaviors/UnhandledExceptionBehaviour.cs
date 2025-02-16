using MediatR;
using Microsoft.Extensions.Logging;

namespace MinimalApi.Application.Common.Behaviors;

public class UnhandledExceptionBehaviour<TRequest, TResponse>(
    ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(e, "Application Unhandled Exception for Request {requestName} {request}", requestName, request);
            throw;
        }
    }
}