using airport_api.Models;

namespace airport_api.Services;

public interface IAirportService
{
    Task<DistanceResponse> GetDistance(IataCode source, IataCode destination);
}