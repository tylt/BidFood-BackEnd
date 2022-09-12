using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BidFood.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string logFile = "logs\\log.txt";
            Log.Logger =
          new LoggerConfiguration()
              .Enrich
              .FromLogContext()
              .Enrich
              .WithEnvironmentName()
              .Enrich
              .WithClientIp()
              .Enrich
              .WithCorrelationId()
              .WriteTo
              .File(logFile,
              outputTemplate: "{Timestamp} [{Level:u3}] {EnvironmentName} {CorrelationId} {ClientIp} {UserId} {Message}{NewLine}{Exception}",
              rollingInterval: RollingInterval.Day,
              fileSizeLimitBytes: null,
              flushToDiskInterval: TimeSpan.FromSeconds(1))
              .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
            .CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logBuilder =>
            {
                logBuilder.SetMinimumLevel(LogLevel.Warning);
            });
    }
}
