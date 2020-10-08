using System.Collections.Generic;
using SampleStatelessWebApi.Models;

namespace SampleStatelessWebApi.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetForecasts();
    }
}