using System.Reflection;
using Clothes.Application.Common.Behaviors;
using Clothes.Application.Identity;
using Clothes.Application.Services.Authentication;
using Clothes.Application.Services.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clothes.Application;

public static class ConfigureApplication
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IJwtFactory, JwtFactory>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}