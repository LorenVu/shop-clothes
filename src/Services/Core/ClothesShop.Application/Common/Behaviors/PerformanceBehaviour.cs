using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clothes.Application.Common.Behaviors;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>

{
    private readonly Stopwatch _stopwatch;
    private readonly ILogger<PerformanceBehaviour<TRequest, TResponse>> _logger;

    public PerformanceBehaviour(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
    {
        _stopwatch = new Stopwatch();
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _stopwatch.Start();
        var response = await next();
        _stopwatch.Stop();

        var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
        if (elapsedMilliseconds >= 500)
            _logger.LogInformation("Application Long Running Request: {requestName} ({elapsedMilliseconds} milliseconds))", typeof(TRequest).Name, elapsedMilliseconds);

        return response;
    }
}