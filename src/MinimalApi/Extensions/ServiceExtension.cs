using Microsoft.EntityFrameworkCore;
using MinimalProject.Infrastructure.Persistences;

namespace MinimalProject.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static void ConfigurePostgresDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");

        services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}