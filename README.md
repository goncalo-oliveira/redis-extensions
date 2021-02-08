# Redis extensions for .NET

This repository contains Rediss service extensions with dependency injection for .NET.

## Installing

Add a package reference from NuGet

```
dotnet add package Faactory.Extensions.Redis
```

## Usage

Just configure the DI container with the service extensions.

```csharp
public void ConfigureServices( IServiceCollection services )
{
    ...

    // add your services here.
    services.AddRedisService( options =>
    {
        options.Connection = "redis-connection-string";
    } );
}
```

And then you can inject the `IRedisService` wherever you need it.

```csharp
public class WeatherController : ControllerBase
{
    public WeatherController( IRedisService redisService )
    {
        IConnectionMultiplexer connection = redisService.Connection;
    }
}
```
