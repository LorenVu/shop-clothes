using System.Reflection;
using Clothes.Application.Common.Behaviors;
using Clothes.Application.Services.Authentication;
using Clothes.Application.Services.Interfaces;
using Clothes.Domain.Configs;
using Clothes.Infrastructure.Repositories;
using Clothes.Infrastructure.Repositories.Interfaces;
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
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBankRepository, BankRepository>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IJwtFactory, JwtFactory>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.Configure<JwtSettings>(settings => configuration.GetSection("JwtSettings"));

        return services;
    }
}