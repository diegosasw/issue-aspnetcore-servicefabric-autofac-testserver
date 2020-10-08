using System.Collections.Generic;

namespace SampleStatelessWebApi.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}