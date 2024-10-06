using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotBasic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                string appSettingEnvPath = $"appsettings.{hostingContext
                                            .HostingEnvironment
                                            .EnvironmentName}.json";
                config.SetBasePath(hostingContext.HostingEnvironment
                                                .ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile(appSettingEnvPath, true, true)
                    .AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            })
            .ConfigureServices(s =>
            {
                s.AddOcelot();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {
                app.UseOcelot().Wait();
            })
            .Build()
            .Run();
        }
    }
}

