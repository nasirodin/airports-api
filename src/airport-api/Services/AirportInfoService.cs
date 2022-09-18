using airport_api.Models;

namespace airport_api.Services;

public class AirportInfoService : IAirportInfoService
{
    private readonly HttpClient _httpClient;

    public AirportInfoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AirportInfoResponse> GetAirportInfo(string iata)
    {
        // todo : validate IATA code
        var response = await _httpClient.GetAsync($"{iata}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var airportInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<AirportInfoResponse>(json);
        return airportInfo ?? new AirportInfoResponse();
    }
}