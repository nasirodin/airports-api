using airport_api.Models;
using Geolocation;

namespace airport_api.Services;

public sealed class AirportService : IAirportService
{
    private readonly ICteleportApi _api;
    private readonly IAirportInfoCache _cache;
    
    public AirportService(ICteleportApi api, IAirportInfoCache cache)
    {
        _api = api;
        _cache = cache;
    }

    public async Task<DistanceResponse> GetDistance(IataCode sourceIata, IataCode destinationIata)
    {
        sourceIata.EnsureIsValid();
        destinationIata.EnsureIsValid();

        var source = await GetAirportInfo(sourceIata);
        var sourceCoordinate = new Coordinate(source.Location.Lat, source.Location.Lon);
        
        var destination = await GetAirportInfo(destinationIata);
        var destinationCoordinate = new Coordinate(destination.Location.Lat, destination.Location.Lon);

        var distance = GeoCalculator.GetDistance(sourceCoordinate, destinationCoordinate, 2, DistanceUnit.Miles);
        return new DistanceResponse
        {
            Distance = distance,
            Destination = destinationIata.Code,
            Source = sourceIata.Code,
            UnitType = DistanceUnit.Miles.ToString()
        };
    }

    private async Task<AirportInfoResponse> GetAirportInfo(IataCode iata)
    {
        var info = await _cache.Get(iata) ?? await _api.GetAirportInfo(iata);
        if (info != null)
            await _cache.Set(info);
        return info ?? AirportInfoResponse.Default;
    }
}