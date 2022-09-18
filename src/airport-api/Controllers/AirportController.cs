using airport_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace airport_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportController : ControllerBase
{
    private readonly ILogger<AirportController> _logger;
    private readonly IAirportInfoService _airportInfoService;
    public AirportController(ILogger<AirportController> logger, 
        IAirportInfoService airportInfoService)
    {
        _logger = logger;
        _airportInfoService = airportInfoService;
    }

    [HttpGet(Name = "GetDistance")]
    public async Task<string> GetDistance()
    {
        var response = await _airportInfoService.GetAirportInfo("AMS");
        return response.Name ?? string.Empty;
    }
}
