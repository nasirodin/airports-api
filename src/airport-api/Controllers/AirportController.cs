using Microsoft.AspNetCore.Mvc;

namespace airport_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportController : ControllerBase
{
    private readonly ILogger<AirportController> _logger;

    public AirportController(ILogger<AirportController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDistance")]
    public string GetDistance()
    {
        return string.Empty;
    }
}
