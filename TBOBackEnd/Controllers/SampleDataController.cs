using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBOBackEnd.Models;

namespace TBOBackEnd.Controllers
{
  [Route("api/[controller]")]
  public class SampleDataController : Controller
  {
    private static string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    [HttpGet("[action]")]
    public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      });
    }
  }
}