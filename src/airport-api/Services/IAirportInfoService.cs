using airport_api.Models;

namespace airport_api.Services;

public interface IAirportInfoService
{
    Task<AirportInfoResponse> GetAirportInfo(string iata);
}