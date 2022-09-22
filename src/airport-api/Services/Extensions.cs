using Polly;
using Polly.Extensions.Http;

namespace airport_api.Services;

public static class Extensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ICteleportApi, CteleportApi>();
        builder.Services.AddSingleton<IAirportService, AirportService>();
        builder.Services.AddSingleton<IAirportInfoCache, AirportInfoCache>();
        
        var apiUrl = builder.Configuration.GetValue<string>("CteleportApiUrl");
        builder.Services.AddHttpClient<ICteleportApi, CteleportApi>(client => { client.BaseAddress = new Uri(apiUrl); })
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