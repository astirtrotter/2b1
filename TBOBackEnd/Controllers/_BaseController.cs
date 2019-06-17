using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBOBackEnd.Controllers
{
  public class _BaseController : Controller
  {
    protected readonly _AppDbContext _context;

    public _BaseController(_AppDbContext context)
    {
      _context = context;
    }
  }
}
