using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog; // Por el nuget Serilog.AspNetCore

namespace windows_worker_service_dotnetcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService() // por el nuget Microsoft.Extensions.Hosting.WindowsServices
                .UseSerilog() // Por el nuget Serilog.AspNetCore
                .ConfigureServices((hostContext, services) =>
                {
                    // DI de serilog
                    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                    // DI del httpClient... 
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                });
    }
}
