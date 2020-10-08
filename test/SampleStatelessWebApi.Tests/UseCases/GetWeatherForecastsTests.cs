using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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

            protected override void ConfigureTestServices(IServiceCollection serviceCollection)
            {
                base.ConfigureTestServices(serviceCollection);
                var weatherServiceMock = new Mock<IWeatherService>();
                weatherServiceMock
                    .Setup(x => x.GetForecasts())
                        .Returns(new List<WeatherForecast>
                        {
                                new WeatherForecast
                                {
                                    Date = new DateTime(2020,10,8,0,0,0,0,DateTimeKind.Utc),
                                    Summary = "This is a mock forecast",
                                    TemperatureC = 10
                                }
                        });

                serviceCollection
                    .AddSingleton<IWeatherService>(sp => weatherServiceMock.Object);
            }

            protected override void Given()
            {
                _expectedForecastsJsonResult =
                    "[{\"date\":\"2020-10-08T00:00:00Z\",\"temperatureC\":10,\"temperatureF\":49,\"summary\":\"This is a mock forecast\"}]";
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
            public void Then_It_Should_Return_Mock_Values()
            {
                _result.Content.ReadAsStringAsync().Result.Should().BeEquivalentTo(_expectedForecastsJsonResult);
            }
        }
    }
}