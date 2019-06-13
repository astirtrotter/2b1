using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models;

namespace TBOBackEnd.Database
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var context = serviceProvider.GetRequiredService<_AppDbContext>();
      context.Database.EnsureCreated();
      if (!context.Admins.Any())
      {
        context.Admins.AddRange(new List<Admin>
        {

        });
        context.SaveChanges();
      }
    }
  }
}
