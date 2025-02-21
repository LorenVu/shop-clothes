using Microsoft.Extensions.Hosting;
using Serilog;

namespace BuildingBlock.Common.Logging;

public class Serilogger
{
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
        (context, configuration) =>
        {
            var environmentName = context.HostingEnvironment.EnvironmentName.ToLower() ?? "Development";
            var applicationName = context.HostingEnvironment.ApplicationName.ToLower().Replace(".", "-") ?? "";
            
            configuration
                .WriteTo.Debug()
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}-{Message:lj}{NewLine}{Exception}{NewLine}")
                .Enrich.FromLogContext()
                //.Enrich.WithMachineName()
                .Enrich.WithProperty("Enviroment", environmentName)
                .Enrich.WithProperty("Application", applicationName)
                .ReadFrom.Configuration(context.Configuration);
        };
}