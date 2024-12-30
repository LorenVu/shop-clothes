using MinimalApi.Application;
using MinimalApi.Infrastructure;
using MinimalProject.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.ConfigurePostgresDbContext(builder.Configuration);
// Add services to the container.
    builder.Services.Configuration();
    builder.Services.ConfigureApplicationServices();
    builder.Services.ConfigureInfrastructureServices();
    builder.Services.AddConfigurationSettings(builder.Configuration);
    builder.Services.AddMinimalEndpoints();
    builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

    var app = builder.Build();

    app.RegisterMinimalEndpoints();

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

    app.UseInfrastructure(builder);
    app.Run();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}