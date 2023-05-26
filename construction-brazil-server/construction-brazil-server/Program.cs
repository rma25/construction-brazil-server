using construction_brazil_server;
using Microsoft.Extensions.Configuration.Json;
using Serilog;

public class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
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
                }).UseSerilog();
}