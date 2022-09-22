using airport_api.Models;

namespace airport_api.Services;

public interface IAirportInfoCache
{
    Task<AirportInfoResponse?> Get(IataCode iata);
    Task Set(AirportInfoResponse airportInfo);
}