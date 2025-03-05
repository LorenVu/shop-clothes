using Basket.API.Extensions;
using Common.Logging;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(Serilogger.Configure);
    Log.Information("Start Basket API up");
    
    builder.Host.AddAppConfiguration();
    builder.Services.AddConfigurationSettings(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
    
    var app = builder.Build();
    app.UseInfrastructure(builder);

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down Basket API complete");
    Log.CloseAndFlush();
}