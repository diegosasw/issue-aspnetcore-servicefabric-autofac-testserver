using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleStatelessWebApi.Services;

namespace SampleStatelessWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecasts()
        {
            _logger.LogInformation("Getting forecasts..");
            var result = await _weatherService.GetForecasts();
            return Ok(result);
        }
    }
}
