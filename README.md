# Sample
The following example shows how can an AspNet Core Web Api application (DotNetCore 3.1) run on service fabric as a stateless service and also:
- Read settings from appsettings.json
- Take into consideration different environments and environment variables
- Have a TestServer in functional tests to provide an easy way to test http requests that go through the whole http middleware pipeline
- Overwrite settings for test values
- Use the same `Startup` class for both real application and tests
- Allow mocking specific services
