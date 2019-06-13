﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TBOBackEnd.Database;

namespace TBOBackEnd
{
  public class Program
  {
    public static void Main(string[] args) => CreateWebHostBuilder(args)
      //.UseKestrel() // default
      //.UseContentRoot(Directory.GetCurrentDirectory()) // default
      .ConfigureLogging((hostingContext, logging) =>
      {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
        logging.AddDebug();
        logging.AddEventSourceLogger();
      })
      .Build()
      .InitDatabase()
      .Run();

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
  }
}
