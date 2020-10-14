# Goal
The goal of this sample is to run AspNetCore with Service Fabric and Autofac and also be able to use integration tests with MS TestServer. The following features should work:
- reading settings from appsettings.json
- take into consideration different environments and environment variables for appsettings.json
- overwrite settings for tests without modifying the "real" code using the same Startup.cs
- overwrite service registrations for mocks when needed in tests.

## Use DotNetCore 3.1 + Service Fabric + Autofac
There is an issue with the generic hosting that AspNetCore3.1 (that comes with DotNetCore3.1) has when trying to use Autofac registrations and run in Service Fabric.
See https://stackoverflow.com/questions/64260534/how-to-use-service-fabric-service-with-aspnet-core-webapi-and-autofac-and-run-te

The workaround is to use AspNetCore 2.2 in the project that tarjets DotNetCore3.1 and be able to use Autofac registration as described here where there is no generic host but webhost and the
`ConfigureServices` method in `Startup.cs` can return a `IServiceProvider`:
https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html#asp-net-core-1-1-2-2

