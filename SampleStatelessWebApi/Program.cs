using Autofac;
using System;
using System.Diagnostics;
using System.Threading;
using Autofac.Integration.ServiceFabric;

namespace SampleStatelessWebApi
{
    public static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                // Autofac
                var builder = new ContainerBuilder();
                builder.RegisterAssemblyModules(typeof(Startup).Assembly);
                builder.RegisterServiceFabricSupport();
                builder.RegisterStatelessService<SampleStatelessWebApi>("SampleStatelessWebApiType");

                using (builder.Build())
                {
                    ServiceEventSource.Current.ServiceTypeRegistered(
                        Process.GetCurrentProcess().Id, 
                        nameof(SampleStatelessWebApi));

                    // Prevents this host process from terminating so services keeps running. 
                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
