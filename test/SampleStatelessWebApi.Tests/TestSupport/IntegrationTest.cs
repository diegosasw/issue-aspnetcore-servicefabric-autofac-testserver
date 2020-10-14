using System;
using System.Net.Http;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleStatelessWebApi.Extensions;

namespace SampleStatelessWebApi.Tests.TestSupport
{
    public abstract class IntegrationTest
        : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        protected HttpClient HttpClient { get; }
        protected IConfiguration Configuration { get; }
        protected IntegrationTest()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .UseCommonConfiguration()
                        .ConfigureServices(services => services.AddAutofac())
                        .UseEnvironment("Test")
                        .ConfigureTestServices(ConfigureTestServices));

            HttpClient = server.CreateClient();
            _serviceProvider = server.Host.Services;
            Configuration = _serviceProvider.GetService<IConfiguration>();
            Setup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        protected T GetService<T>() where T: class
        {
            return _serviceProvider.GetService<T>();
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
