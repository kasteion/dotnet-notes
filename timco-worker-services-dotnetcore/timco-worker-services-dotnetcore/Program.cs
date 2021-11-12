using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog; // Para poder utilizar serilog & por los nugets que se instalaron

namespace timco_worker_services_dotnetcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Así se puede inicializar el logger de serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\temp\workerservice\LogFile.txt")
                .CreateLogger();
            try
            {
                Log.Information("Starting up the service");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the service");
                return;
            } 
            finally
            {
                // Asegura que si hay mensajes en el buffer que los escriba antes de que cerremos nuestra aplicación.
                Log.CloseAndFlush();
            }
            // CreateHostBuilder(args).Build().Run();
        }

        // Agregamos el UseSerilog para que use serilog en lugar de la configuración por defecto que genera el CreateDefaultBuilder
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService() // Y aquí para poder usar el Worker Service como Windows Services
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                }).UseSerilog(); 
                
    }
}
