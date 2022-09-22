﻿using Polly;
using Polly.Extensions.Http;

namespace airport_api.Services;

public static class Extensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICteleportApi, CteleportApi>();
        services.AddSingleton<IAirportService, AirportService>();
        services.AddSingleton<IAirportInfoCache, AirportInfoCache>();
        
        // todo : read api base address from config
        services.AddHttpClient<ICteleportApi, CteleportApi>(client => { client.BaseAddress = new Uri("https://places-dev.cteleport.com/airports/"); })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}