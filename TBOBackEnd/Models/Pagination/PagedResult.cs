using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models.Pagination
{
  public class PagedResult<T> : _PagedResultBase where T : class
  {
    public IList<T> Items { get; set; }

    public PagedResult()
    {
      Items = new List<T>();
    }
  }
}
