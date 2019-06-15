using System;
using System.Collections.Generic;
using System.Linq;
using TBOBackEnd.Models;
using TBOBackEnd.Utils;

namespace TBOBackEnd.Database
{
  public static partial class SeedData
  {
    private static void SeedAdmins(_AppDbContext context)
    {
      if (context.Admins.Any()) return;

      var accountStatusValues = Enum.GetValues(typeof(AccountStatus));
      context.Admins.AddRange(Enumerable.Range(1, 5).Select(index => new Admin
      {
        Id = RandomGenerator.GenerateUUID(),
        FirstName = RandomGenerator.GenerateName(),
        LastName = RandomGenerator.GenerateName(),
        Email = RandomGenerator.GenerateEmail(index),
        AdminAccountStatusId = (AccountStatus)accountStatusValues.GetValue(RandomGenerator.GenerateNumber(accountStatusValues.Length)),
        LastAccessedAt = DateTime.Now
      }));
      context.SaveChanges();
    }
  }
}