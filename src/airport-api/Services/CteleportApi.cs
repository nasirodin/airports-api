using airport_api.Models;

namespace airport_api.Services;

public class CteleportApi : ICteleportApi
{
    private readonly HttpClient _httpClient;

    public CteleportApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AirportInfoResponse?> GetAirportInfo(IataCode iata)
    {
        if (iata.IsValid() == false) return null;

            var response = await _httpClient.GetAsync($"{iata.Code}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var airportInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<AirportInfoResponse>(json);
        return airportInfo ?? new AirportInfoResponse();
    }
}