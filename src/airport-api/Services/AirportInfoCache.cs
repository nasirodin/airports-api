using airport_api.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace airport_api.Services;

public class AirportInfoCache : IAirportInfoCache
{
    private readonly IDistributedCache _cache;

    public AirportInfoCache(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<AirportInfoResponse?> Get(IataCode iata)
    {
        var recordId = iata.Code;
        var jsonData = await _cache.GetStringAsync(recordId);
        return jsonData != null ? JsonConvert.DeserializeObject<AirportInfoResponse>(jsonData) : null;
    }

    public async  Task Set(AirportInfoResponse airportInfo,TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
    {
        var recordId = airportInfo.Iata;
        
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(60),
            SlidingExpiration = slidingExpireTime
        };

        var jsonData = JsonConvert.SerializeObject(airportInfo);
        await _cache.SetStringAsync(recordId, jsonData, options);
    }
}