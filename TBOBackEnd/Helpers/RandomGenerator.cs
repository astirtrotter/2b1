using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBOBackEnd.Helpers
{
  public static class RandomGenerator
  {
    private static Random random = new Random();

    public static int GenerateNumber(int max)
    {
      return random.Next(max);
    }

    public static string GenerateText(int size, bool lowercase = true)
    {
      StringBuilder builder = new StringBuilder();
      Random random = new Random();
      char ch;
      for (int i = 0; i < size; i++)
      {
        ch = Convert.ToChar(GenerateNumber(26) + 65);
        builder.Append(ch);
      }
      if (lowercase)
        return builder.ToString().ToLower();

      return builder.ToString();
    }

    internal static string GenerateUUID()
    {
      return Guid.NewGuid().ToString();
    }

    public static string GenerateEmail(int index = -1)
    {
      return new StringBuilder()
        .Append("random")
        .Append(index == -1 ? "" : index.ToString("d3"))
        .Append('.')
        .Append(GenerateText(5))
        .Append('.')
        .Append(GenerateText(5))
        .Append("@tbo.com")
        .ToString();
    }

    public static string GenerateName()
    {
      // size: [5, 10)
      return GenerateText(GenerateNumber(5) + 5).Capitalize();
    }

    public static string GenerateFullName()
    {
      return GenerateName() + " " + GenerateName();
    }
  }
}
