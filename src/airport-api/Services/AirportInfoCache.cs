using airport_api.Models;

namespace airport_api.Services;

public class AirportInfoCache : IAirportInfoCache
{
    public async Task<AirportInfoResponse?> Get(IataCode iata)
    {
        return null;
    }

    public async  Task Set(AirportInfoResponse airportInfo)
    {
        
    }
}