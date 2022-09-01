using Microsoft.AspNetCore;
using Serilog;
using Serilog.Events;
using System.Diagnostics;

namespace DogExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .WriteTo.File(BuildLogPath())
               .CreateBootstrapLogger();

            try
            {
                Log.Information("Starting web host");
                var app = WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();
                await app.RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        public static string BuildLogPath()
        {
            var startupPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName) ?? "C:\\Logs";
            return Path.Combine(startupPath, "DogExample.log");
        }
    }
}

