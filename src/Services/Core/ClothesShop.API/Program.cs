using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Persistences.Seedings;
using ClothesShop.API.Extensions;
using Common.Logging;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(Serilogger.Configure);
    Log.Information("Start ClothesShop API up");
    
    builder.Host.AddAppConfiguration();
    builder.Services.AddConfigurationSettings(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
    
    var app = builder.Build();
    app.UseInfrastructure(builder);
            
    app.MigrateDatabase<ApplicationDbContext>((context, _) =>
        {
            BrandContextSeed.SeedBrandAsync(context, Log.Logger).Wait();
            CategoryContextSeed.SeedCategoryAsync(context, Log.Logger).Wait();
            ProductContextSeed.SeedProductAsync(context, Log.Logger).Wait();
        })
        .Run();
}
catch(Exception ex)
{
    //Block error when generate migrations
    var type = ex.GetType().Name;    
    if(type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;
            
    Log.Error(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down ClothesShop API complete");
    Log.CloseAndFlush();
}