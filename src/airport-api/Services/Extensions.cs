using Polly;
using Polly.Extensions.Http;

namespace airport_api.Services;

public static class Extensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IAirportInfoService, AirportInfoService>();
        // todo : read api base address from config
        services.AddHttpClient<IAirportInfoService, AirportInfoService>(client => { client.BaseAddress = new Uri("https://places-dev.cteleport.com/airports/"); })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                retryAttempt)));
    }
}