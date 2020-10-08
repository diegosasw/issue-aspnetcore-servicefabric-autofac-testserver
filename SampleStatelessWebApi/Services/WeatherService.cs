using System.Collections.Generic;
using System.Threading.Tasks;
using SampleStatelessWebApi.Models;

namespace SampleStatelessWebApi.Services
{
    public class WeatherService
        : IWeatherService
    {
        public Task<IEnumerable<WeatherForecast>> GetForecasts()
        {
            var hardcodedForecasts =
                new List<WeatherForecast>
                {
                    new WeatherForecast("Sunny"),
                    new WeatherForecast("Mild"),
                    new WeatherForecast("Chilly")
                };
            var result = Task.FromResult((IEnumerable<WeatherForecast>) hardcodedForecasts);
            result.ConfigureAwait(false);
            return result;
        }
    }
}
