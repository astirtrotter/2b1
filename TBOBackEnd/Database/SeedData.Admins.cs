using System.Collections.Generic;
using System.Linq;
using TBOBackEnd.Models;

namespace TBOBackEnd.Database
{
  public static partial class SeedData
  {
    private static void SeedAdmins(_AppDbContext context)
    {
      if (context.Admins.Any()) return;

      context.Admins.AddRange(new List<Admin>
      {

      });
      context.SaveChanges();
    }
  }
}