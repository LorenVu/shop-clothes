using Microsoft.EntityFrameworkCore;

namespace ClothesShop.API.Extensions;

public static class HostExtension
{
    //Run project auto migrate database when it changed
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation("Migrating postgreSql database");
                ExecuteMigrations(context);                
                logger.LogInformation("Migrated postgreSql database");
                InvokeSeeder(seeder, context, services);
            }   
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrate the database.");
            }
        }
        
        return host;
    }

    private static void ExecuteMigrations<TContext>(TContext context) where TContext : DbContext
    {
        context.Database.Migrate();
    }
    
    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, 
        TContext context, IServiceProvider services) where TContext : DbContext
    {
        //Action delegate 
        seeder(context, services);
    }
}