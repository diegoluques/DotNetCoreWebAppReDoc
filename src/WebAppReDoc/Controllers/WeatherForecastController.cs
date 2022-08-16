using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppReDoc.Controllers
{/// <summary>
 /// Weather Forecasts
 /// </summary>
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Get Weather forecast and place orders. Very weird and unstructed API :)")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        /// <summary>
        /// Constructor for Dependency Injection
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Return 5 random weather forecasts
        /// </summary>
        /// <remarks>
        /// This endpoint will return 5 days of weather forecasts with random temperatures in celcius.
        /// </remarks>
        /// <returns>5 Weather forecasts</returns>
        /// <response code="200">Returns the weather forecasts</response>
        [HttpGet]
        [SwaggerOperation(
    Summary = "Get Weather Forecast",
    Description = "This endpoint will return 5 days of weather forecasts with random temperatures in celcius.",
    OperationId = "Get",
    Tags = new[] { "WeatherForecast" })]
        [SwaggerResponse(200, "The random weather forecasts", typeof(WeatherForecast))]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
