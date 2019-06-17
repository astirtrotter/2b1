using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models.Pagination
{
  public static class LinqExtensions
  {
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
      var result = new PagedResult<T>();
      result.CurrentPage = page;
      result.PageSize = pageSize;
      result.TotalCount = query.Count();
      result.PageCount = (int)Math.Ceiling((double)result.TotalCount / pageSize);

      var skip = (page - 1) * pageSize;
      result.Items = query.Skip(skip).Take(pageSize).ToList();

      return result;
    }
  }
}
