using System;
using System.Collections.Generic;
using System.Linq;
using SampleStatelessWebApi.Models;

namespace SampleStatelessWebApi.Services
{
    public class WeatherService
        : IWeatherService
    {
        public IEnumerable<WeatherForecast> GetForecasts()
        {
            var result =
                new List<WeatherForecast>
                {
                    new WeatherForecast("Sunny"),
                    new WeatherForecast("Mild"),
                    new WeatherForecast("Chilly")
                };
            return result;
        }
    }
}
