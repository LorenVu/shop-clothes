namespace Basket.API.Extensions;

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
                .AddJsonFile("response-message.json", optional: false, reloadOnChange: true)
                // .AddUserSecrets<Program>(false)  // Explicit use secrets.json in env production, staging. By default it only use in development
                .AddEnvironmentVariables();
        });
#pragma warning restore ASP0013
    }
}