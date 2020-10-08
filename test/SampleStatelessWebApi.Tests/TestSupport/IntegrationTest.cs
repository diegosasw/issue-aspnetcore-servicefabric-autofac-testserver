using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace SampleStatelessWebApi.Tests.TestSupport
{
    public abstract class IntegrationTest
        : IDisposable
    {
        protected HttpClient HttpClient { get; }
        protected IntegrationTest()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .ConfigureTestServices(ConfigureTestServices));
            HttpClient = server.CreateClient();

            Setup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        protected virtual void ConfigureTestServices(IServiceCollection serviceCollection)
        {
        }

        protected virtual void Cleanup()
        {
        }

        protected abstract void Given();

        protected abstract void When();

        private void Setup()
        {
            Given();
            When();
        }
    }
}
