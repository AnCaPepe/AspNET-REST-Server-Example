using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using school_server.Data;
using school_server.Models;

namespace school_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorsController : ControllerBase
    {
        // private readonly DataContext context;
        public ProfessorsController(/*DataContext dbContext*/)
        {
            // this.DbContext = dbContext;
            // context = dbContext;
        }

        // [HttpGet]
        // public IActionResult Get()
        // {
        //     try
        //     {
        //         return Ok(context.Professors.ToList());
        //     }
        //     catch (Exception e)
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine(e);
        //         Console.ForegroundColor = ConsoleColor.White;
        //     }

        //     return NotFound();
        // }

        // [HttpGet]
        // public IActionResult Get(int id)
        // {
        //     try
        //     {
        //         return Ok(context.Professors.Where(x => x.Id == id).First());
        //     }
        //     catch (Exception e)
        //     {
        //         Console.ForegroundColor = ConsoleColor.Red;
        //         Console.WriteLine(e);
        //         Console.ForegroundColor = ConsoleColor.White;
        //     }

        //     return NotFound();
        // }

        // [HttpPost]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        // [HttpPut]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        // [HttpDelete]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}