using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Domain.Constracts;
using MinimalApi.Infrastructure.Repositories;
using MinimalApi.Infrastructure.Repositories.Interfaces;
using MinimalApi.Infrastructure.Repositories.UnitOfWork;

namespace MinimalApi.Infrastructure;

public static class ConfigureInfrastructure
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}