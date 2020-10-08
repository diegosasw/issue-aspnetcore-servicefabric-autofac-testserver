namespace SampleStatelessWebApi.Models
{
    public class WeatherForecast
    {
        public string Summary { get; }

        public WeatherForecast(string summary)
        {
            Summary = summary;
        }
    }
}
