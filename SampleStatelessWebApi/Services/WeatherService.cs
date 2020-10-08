using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleStatelessWebApi.Services
{
    public class WeatherService
        : IWeatherService
    {
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = summaries[rng.Next(summaries.Length)]
                })
                .ToArray();
        }
    }
}
