namespace airport_api.Models;

public sealed class DistanceResponse
{
    public string? Source { get; set; }
    public string? Destination { get; set; }
    public double? Distance { get; set; }
    public string? UnitType { get; set; }
}