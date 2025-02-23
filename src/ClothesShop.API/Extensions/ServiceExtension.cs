using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Clothes.Application;
using Clothes.Application.Services.Interfaces;
using Clothes.Application.Services.Transactions;
using Clothes.Domain.Configs;
using Clothes.Domain.Extensions;
using Clothes.Infrastructure;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Shared.Responses;
using ClothesShop.API.Controllers.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClothesShop.API.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var sePayConfig = configuration.GetSection(nameof(SepayConfigs)).Get<SepayConfigs>();
        ArgumentNullException.ThrowIfNull(sePayConfig);
        services.AddSingleton(sePayConfig);
        
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>(x => x.BindNonPublicProperties = true);
        ArgumentNullException.ThrowIfNull(jwtSettings);
        services.AddSingleton(jwtSettings);

        configuration.GetSection(nameof(ResponseMessageConfig)).Get<ResponseMessageConfig>(x => x.BindNonPublicProperties = true);

        return services;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ApplyTimeoutProfile();
        services.AddControllers(opt =>
            {
                opt.ApplyCacheProfile(); 
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
        services.ConfigurePostgresDbContext(configuration);
        //services.AddInfrastructureServices();
        services.ConfigureInfrastructureServices();
        services.ConfigureApplicationServices(configuration);
        services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
        services.ConfigureHttpClients();
        services.AddJwtBearerAuthentication(configuration);
        services.AddResponseCompression(options => { options.EnableForHttps = true; });
        
        return services;
    }

    private static void ConfigurePostgresDbContext(this IServiceCollection services, IConfiguration configuration)
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
        services.AddHttpClient<ISepayTransactionService, SepayTransactionService>("TransactionsApi", (sp, cl) => {
            cl.BaseAddress = new Uri("https://my.sepay.vn/userapi");
        });

        services.AddScoped(sp => sp.GetService<IHttpClientFactory>()
            .CreateClient("TransactionsApi"));
    }
    
    private static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>(x => x.BindNonPublicProperties = true);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, // default True
                ValidIssuer = jwtSettings.Issuer ?? string.Empty,
                ValidateIssuerSigningKey = true,    
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey ?? string.Empty)),
                ValidAudience = jwtSettings.Audience,
                ValidateAudience = true, // default True
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)
            };
            x.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context => 
                {
                    context.Response.OnStarting(async () =>
                    {
                        var response = context.Response;

                        response.ContentType = MediaTypeNames.Application.Json;
                        await response.WriteAsync(new ApiFailedResult<object>()
                            .WithMessage(CodeResponseMessage.TokenIsNull)
                            .MySerialize());
                    });

                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    context.Response.OnStarting(async () =>
                    {
                        var response = context.Response;

                        response.ContentType = MediaTypeNames.Application.Json;
                        await response.WriteAsync(new ApiFailedResult<object>()
                            .WithMessage(CodeResponseMessage.NotSystemAccessPermission)
                            .MySerialize());
                    });

                    return Task.CompletedTask;
                }
            };
        });
    }
}