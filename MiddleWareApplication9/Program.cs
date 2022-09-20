using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWareApplication9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputTemplate = "{Timestamp:yyyy-MM-dd HH: mm: ss. [{Level}] {Message}{ NewLine}{ Exception}";

            Log.Logger = new
                   LoggerConfiguration().WriteTo.File("C:\\Logs\\Demo.txt",
                   rollingInterval: RollingInterval.Day, outputTemplate:
                   outputTemplate).CreateLogger();
           



            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseSerilog();
    }
}
