using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Api
{
    /// <summary>
    /// Api program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main Program
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration() // Configure Serilog for logging
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File("logs\\log-.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();

            CreateWebHostBuilder(args).Run();
        }

        /// <summary>
        /// Create Web host Builder
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(c => c.AddServerHeader = false)
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                IHostingEnvironment env = builderContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
            //.UseIISIntegration()
            .UseStartup<Startup>()
            .UseSerilog()
            .Build();
    }
}
