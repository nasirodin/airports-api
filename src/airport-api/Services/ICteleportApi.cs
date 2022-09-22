using airport_api.Models;

namespace airport_api.Services;

public interface ICteleportApi
{
    Task<AirportInfoResponse?> GetAirportInfo(IataCode iata);
}