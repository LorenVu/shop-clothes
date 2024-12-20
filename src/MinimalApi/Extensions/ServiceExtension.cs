using Microsoft.EntityFrameworkCore;
using MinimalProject.Infrastructure.Persistences;

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

        return services;
    }

    public static void ConfigurePostgresDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");

        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}