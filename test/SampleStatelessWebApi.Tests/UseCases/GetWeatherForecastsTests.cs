using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SampleStatelessWebApi.Models;
using SampleStatelessWebApi.Services;
using SampleStatelessWebApi.Tests.TestSupport;
using Xunit;

namespace SampleStatelessWebApi.Tests.UseCases
{
    public static class GetWeatherForecastsTests
    {
        public class Given_The_Url_When_Getting_Weather_Forecasts
            : IntegrationTest
        {
            private HttpResponseMessage _result;
            private string _expectedForecastsJsonResult;

            protected override void Given()
            {
                _expectedForecastsJsonResult =
                    "[{\"summary\":\"Sunny\"},{\"summary\":\"Mild\"},{\"summary\":\"Chilly\"}]";
            }

            protected override void When()
            {
                _result = HttpClient.GetAsync("weatherForecast").GetAwaiter().GetResult();
            }

            [Fact]
            public void Then_It_Should_Return_200_Ok()
            {
                _result.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Fact]
            public async Task Then_It_Should_Return_Expected_Json()
            {
                var resultAsJson = await _result.Content.ReadAsStringAsync();
                resultAsJson.Should().BeEquivalentTo(_expectedForecastsJsonResult);
            }
        }

        public class Given_The_Url_And_Mock_Weather_Forecast_Service_When_Getting_Weather_Forecasts
            : IntegrationTest
        {
            private HttpResponseMessage _result;
            private string _expectedForecastsJsonResult;

            protected override void ConfigureTestServices(IServiceCollection serviceCollection)
            {
                base.ConfigureTestServices(serviceCollection);
                var weatherServiceMock = new Mock<IWeatherService>();
                weatherServiceMock
                    .Setup(x => x.GetForecasts())
                    .ReturnsAsync(new List<WeatherForecast>
                    {
                        new WeatherForecast("Raining cats and dogs")
                    });

                serviceCollection
                    .AddSingleton<IWeatherService>(sp => weatherServiceMock.Object);
            }

            protected override void Given()
            {
                _expectedForecastsJsonResult = "[{\"summary\":\"Raining cats and dogs\"}]";
            }

            protected override void When()
            {
                _result = HttpClient.GetAsync("weatherForecast").GetAwaiter().GetResult();
            }

            [Fact]
            public void Then_It_Should_Return_200_Ok()
            {
                _result.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Fact]
            public async Task Then_It_Should_Return_Expected_Json()
            {
                var resultAsJson = await _result.Content.ReadAsStringAsync();
                resultAsJson.Should().BeEquivalentTo(_expectedForecastsJsonResult);
            }
        }
    }
}