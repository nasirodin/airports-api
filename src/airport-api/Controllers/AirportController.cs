using airport_api.Models;
using airport_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace airport_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportController : ControllerBase
{
    private readonly ILogger<AirportController> _logger;
    private readonly IAirportService _service;
    public AirportController(ILogger<AirportController> logger, IAirportService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "GetDistance")]
    public async Task<DistanceResponse> GetDistance(string source, string destination)
    {
        var response = await _service.GetDistance(new IataCode(source), new IataCode(destination));
        return response;
    }
}
