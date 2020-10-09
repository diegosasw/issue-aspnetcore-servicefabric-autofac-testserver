using Autofac;
using SampleStatelessWebApi.Services;

namespace SampleStatelessWebApi.IoCC.Autofac
{
    public class ServicesModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<WeatherService>()
                .As<IWeatherService>()
                .InstancePerDependency();
        }
    }
}
