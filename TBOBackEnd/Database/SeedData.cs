using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models;
using TBOBackEnd.Helpers;

namespace TBOBackEnd.Database
{
  public static partial class SeedData
  {
    public static IWebHost InitDatabase(this IWebHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var serviceProvider = scope.ServiceProvider;
        var log = LogManager.GetLogger(Startup.repository.Name, typeof(SeedData));
        try
        {
          var context = serviceProvider.GetRequiredService<_AppDbContext>();
          context.Database.EnsureCreated();
          SeedAdminAccountStatus(context);
          SeedAdmins(context);
          SeedAdminRoles(context);

          log.Debug("Seeding the database has been successfully finished.");
        }
        catch (Exception e)
        {
          log.Debug(e);
          log.Debug("An error occurred while seeding the database.");
        }
      }

      return host;
    }
  }
}
