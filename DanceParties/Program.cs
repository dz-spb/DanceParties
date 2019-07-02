using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DanceParties.Logger;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DanceParties
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .ConfigureAppConfiguration((hostingContext, config) =>
            //    {
            //        var env = hostingContext.HostingEnvironment;
            //        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //              .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
            //                  optional: true, reloadOnChange: true);
            //        config.AddEnvironmentVariables();
            //    })
            //    .ConfigureLogging((hostingContext, logging) =>
            //    {
            //        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            //        logging.AddConsole();
            //        logging.AddDebug();
            //        logging.AddEventSourceLogger();
            //        logging.AddProvider(new FileLoggerProvider(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")));
            //    })
                .UseStartup<Startup>();
                //.ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Trace));
    }
}
