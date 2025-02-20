using Clothes.Application;
using Clothes.Infrastructure;
using ClothesShop.API.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigurePostgresDbContext(builder.Configuration);
// Add services to the container.
    builder.Services.Configuration(builder.Configuration);
    builder.Services.ConfigureApplicationServices(builder.Configuration);
    builder.Services.ConfigureInfrastructureServices();
    builder.Services.AddConfigurationSettings(builder.Configuration);
    builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    builder.Services.AddControllers();
    //builder.Services.AddHealthCheck();
    builder.Services.AddEndpointsApiExplorer(); 
    
    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        //Redirect to swagger
        app.MapGet("/", () => 
            Results.Redirect("~/swagger")
        );
    }
    
    if (app.Environment.IsProduction())
        app.UseHttpsRedirection();
    
    app.UseInfrastructure(builder);
    app.MapControllers();
    app.Run();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}