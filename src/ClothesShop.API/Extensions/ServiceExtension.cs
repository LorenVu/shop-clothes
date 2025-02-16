using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Configs;
using MinimalApi.Infrastructure.Persistences;
using MinimalApi.Infrastructure.Repositories;
using MinimalApi.Infrastructure.Repositories.Interfaces;

namespace MinimalProject.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            // options =>
            // {
            //     // Dynamically add Swagger document groups based on endpoint versions
            //     options.DocInclusionPredicate((docName, apiDesc) => 
            //         apiDesc.RelativePath != null 
            //         && apiDesc.RelativePath.StartsWith(docName, StringComparison.OrdinalIgnoreCase));
            //
            //     // Add Swagger document for each version-group
            //     options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //     {
            //         Title = "API v1",
            //         Version = "v1",
            //     });
            //
            //     options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
            //     {
            //         Title = "API v2",
            //         Version = "v2",
            //     });
            // }
            );

        services.ConfigureHttpClients();
        
        return services;
    }

    public static void AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var sePayConfig = configuration.GetSection(nameof(SepayConfig)).Get<SepayConfig>();
        if (sePayConfig != null)
            services.AddSingleton(sePayConfig);
    }
    
    public static void ConfigurePostgresDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");

        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
    
    private static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.ConfigureTransactionHttpClient();
    }
    
    private static void ConfigureTransactionHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<ITransactionRepository, TransactionRepository>("TransactionsApi", (sp, cl) =>
        {
            cl.BaseAddress = new Uri("https://my.sepay.vn/userapi");
        });
        
        services.AddScoped(sp => sp.GetService<IHttpClientFactory>()
            .CreateClient("TransactionsApi"));
    }
}