using System.Net.Mime;
using System.Text;
using Clothes.Domain.Configs;
using Clothes.Domain.Extensions;
using Clothes.Infrastructure.Persistences;
using Clothes.Infrastructure.Repositories;
using Clothes.Infrastructure.Repositories.Interfaces;
using Clothes.Infrastructure.Shared.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ClothesShop.API.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection Configuration(this IServiceCollection services, IConfiguration configuration)
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
        
        services.AddResponseCaching();
        services.AddJwtBearerAuthentication(configuration);
        services.AddAuthorization();

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
    
    private static void AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>(x => x.BindNonPublicProperties = true);
        ArgumentNullException.ThrowIfNull(jwtSettings);
        
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