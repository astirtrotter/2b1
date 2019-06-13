using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models;

namespace TBOBackEnd.Database
{
  public static partial class SeedData
  {
    public static IWebHost InitDatabase(this IWebHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var serviceProvider = scope.ServiceProvider;
        try
        {
          var context = serviceProvider.GetRequiredService<_AppDbContext>();
          context.Database.EnsureCreated();
          SeedAdmins(context);
          SeedAdminRoles(context);
        }
        catch (Exception e)
        {
          var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
          logger.LogError(e, "An error occurred while seeding the database.");
        }
      }

      return host;
    }
  }
}
