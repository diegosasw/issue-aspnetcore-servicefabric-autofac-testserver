# issue-aspnetcore-servicefabric-autofac-testserver
Sample for AspNet Core 3.1, Autofac and Test Server in a Service Fabric service


## Gotchas

### Dependencies
`Autofac.ServiceFabric` nuGet package is going to require 
`Microsoft.ServiceFabric.Diagnostics.Internal` in order to be installed.
But there is a warning on some version, so it's adviced to actually
install `Microsoft.ServiceFabric.Actors` instead that already contains
all the necessary dependencies, and later `Autofac.ServiceFabric`

