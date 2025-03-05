using System.Text.Json;
using System.Text.Json.Serialization;
using BuildingBlock.Shared.Configs;
using Clothes.Domain.Extensions;

namespace Basket.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddConfigurationSettings(this IServiceCollection services,
        IConfiguration configuration)
    {
        var redisConfigs = configuration.GetSection(nameof(CacheSettings)).Get<SepayConfigs>();
        services.AddSingleton(redisConfigs);        
        configuration.GetSection(nameof(CacheSettings)).Get<CacheSettings>(x => x.BindNonPublicProperties = true);
        
        return services;
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.ApplyTimeoutProfile();
        services.AddControllers(opt =>
            {
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new MyDateTimeConverter());
                options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;
            });
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureRedis(configuration);
        //services.AddInfrastructureServices();
        services.ConfigureServices();
        services.AddResponseCompression(options => { options.EnableForHttps = true; });
    }

    private static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Basket_";
        });
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        
    }

    public static IServiceCollection ConfigureGrpcServices(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection(nameof(GrpcSettings))
            .Get<GrpcSettings>();
        
        // Inventory Grpc
        // services.AddGrpcClient<StockProtoService.StockProtoServiceClient>(x => x.Address = new Uri(settings.StockUrl));
        // services.AddScoped<StockItemGrpcService>();
        
        return services;
    }
}