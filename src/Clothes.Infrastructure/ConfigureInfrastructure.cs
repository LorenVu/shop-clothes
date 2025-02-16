using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Domain.Constracts;
using MinimalApi.Infrastructure.Repositories;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Repositories.UnitOfWork;
using Scrutor;

namespace MinimalApi.Infrastructure;

public static class ConfigureInfrastructure
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .ConfigureRepositories();

        return services;
    }

    private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsSelf() 
            .WithScopedLifetime());
        
        return services;
    }
}