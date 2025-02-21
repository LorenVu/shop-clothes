namespace ClothesShop.API.Extensions;

public static class ConfigureHostExtensions
{
    public static void AddAppConfiguration(this ConfigureHostBuilder host)
    {
#pragma warning disable ASP0013
        host.ConfigureAppConfiguration((context, config) =>
        {
            var env = context.HostingEnvironment;
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        });
#pragma warning restore ASP0013
    }
}