using System.Collections.Generic;
using System.Threading.Tasks;
using SampleStatelessWebApi.Models;

namespace SampleStatelessWebApi.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecasts();
    }
}