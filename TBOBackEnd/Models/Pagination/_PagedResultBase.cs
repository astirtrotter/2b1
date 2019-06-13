using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Models
{
  public class _PagedResultBase
  {
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public int FirstRowOnPage { get => (CurrentPage - 1) * PageSize + 1; }
    public int LastRowOnPage { get => Math.Min(CurrentPage * PageSize, TotalCount); }
  }
}
