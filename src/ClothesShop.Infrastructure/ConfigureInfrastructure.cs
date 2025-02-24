using BuildingBlock.Shared.Contracts.Domains.Interfaces;
using Clothes.Infrastructure.Repositories;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Repositories.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Clothes.Infrastructure;

public static class ConfigureInfrastructure
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IRepositoryBaseAsync<,,>), typeof(RepositoryBaseAsync<,,>))
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ITransactionRepository, TransactionRepository>()
            .AddScoped<IBankRepository, BankRepository>()
            ;

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