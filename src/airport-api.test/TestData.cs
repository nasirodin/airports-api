using airport_api.Models;

namespace airport_api.test;

public class TestData
{
    public class Airports
    {
        internal static AirportInfoResponse AMS =>
            new AirportInfoResponse()
            {
                Iata = "AMS",
                Country = "Netherlands",
                City = "Amsterdam",
                Location = new Location()
                {
                    Lat = 52.309069,
                    Lon = 4.763385
                }
            };
        
        internal static AirportInfoResponse IKA =>
            new AirportInfoResponse()
            {
                Iata = "IKA",
                Country = "Iran",
                City = "Tehran",
                Location = new Location()
                {
                    Lat = 35.408632,
                    Lon = 51.1548
                }
            };
    }
}