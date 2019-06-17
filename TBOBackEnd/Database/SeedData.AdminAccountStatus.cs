using System;
using System.Collections.Generic;
using System.Linq;
using TBOBackEnd.Models;

namespace TBOBackEnd.Database
{
  public static partial class SeedData
  {
    private static void SeedAdminAccountStatus(_AppDbContext context)
    {
      if (context.AdminAccountStatuses.Any()) return;

      Array accountStatusValues = Enum.GetValues(typeof(AccountStatus));
      context.AdminAccountStatuses.AddRange(Enumerable.Range(0, accountStatusValues.Length).Select(index => new AdminAccountStatus
      {
        AccountStatus = (AccountStatus)accountStatusValues.GetValue(index),
        Description = ((AccountStatus)accountStatusValues.GetValue(index)).ToName()
      }));
      context.SaveChanges();
    }
  }
}