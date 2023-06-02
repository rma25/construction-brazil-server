using construction_brazil_server;
using Microsoft.Extensions.Configuration.Json;
using Serilog;
using Serilog.Events;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Verbose()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                   .MinimumLevel.Override("System", LogEventLevel.Warning)
                   .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                   .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                   .Enrich.FromLogContext()
                   .WriteTo.Console()
                   .CreateLogger();

        try
        {
            Log.Logger.Information("Starting Create Host Builder...");

            return Host.CreateDefaultBuilder(args)
                       .ConfigureLogging(logging => logging.AddSerilog())
                       .ConfigureAppConfiguration((hostingContext, appConfiguration) =>
                       {
                           var env = hostingContext.HostingEnvironment;
                           IConfigurationSource source = appConfiguration.Sources.Last(s =>
                               (s as JsonConfigurationSource)?.Path == $"appsettings.{env.EnvironmentName}.json");

                           int index = appConfiguration.Sources.IndexOf(source);

                           appConfiguration.Sources.Insert(
                               index + 1,
                               new JsonConfigurationSource
                               {
                                   Path = "appsettings.local.json",
                                   Optional = true,
                                   ReloadOnChange = true
                               });

                       })
                       .ConfigureWebHostDefaults(
                           webBuilder =>
                           {
                               webBuilder.ConfigureAppConfiguration(
                                   (hostingContext, config) =>
                                   {
                                       IWebHostEnvironment env = hostingContext.HostingEnvironment;
                                       IConfigurationSource source = config.Sources.Last(s =>
                                           (s as JsonConfigurationSource)?.Path == $"appsettings.{env.EnvironmentName}.json");

                                       int index = config.Sources.IndexOf(source);

                                       config.Sources.Insert(
                                           index + 1,
                                           new JsonConfigurationSource
                                           {
                                               Path = "appsettings.local.json",
                                               Optional = true,
                                               ReloadOnChange = true
                                           });
                                   });
                               webBuilder.UseStartup<Startup>();
                           })
                       .UseSerilog();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host builder error");

            throw;
        }
    }

}