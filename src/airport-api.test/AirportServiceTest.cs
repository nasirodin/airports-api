using airport_api.Models;
using airport_api.Services;
using FluentAssertions;
using Moq;

namespace airport_api.test;

public class AirportServiceTest
{
    private readonly AirportService _sut;
    private readonly Mock<ICteleportApi> _fakeApi;
    private readonly Mock<IAirportInfoCache> _fackeCache;
    public AirportServiceTest()
    {
        _fakeApi = new Mock<ICteleportApi>();
        _fakeApi.Setup(a => a.GetAirportInfo(new IataCode("AMS"))).ReturnsAsync(TestData.Airports.AMS);
        _fakeApi.Setup(a => a.GetAirportInfo(new IataCode("IKA"))).ReturnsAsync(TestData.Airports.IKA);
        
        _fackeCache = new Mock<IAirportInfoCache>();
        _fackeCache.Setup(c => c.Get(It.IsAny<IataCode>())).ReturnsAsync(default(AirportInfoResponse));
        
        _sut = new AirportService(_fakeApi.Object, _fackeCache.Object);
    }
    
    [Fact]
    public async Task Same_IATA_ShouldReturns_ZeroDistance()
    {
        var actual = await _sut.GetDistance(new IataCode("AMS"), new IataCode("AMS"));
        actual.Should().NotBeNull();
        actual.Distance.Should().Be(0);
    }

    [Fact]
    public async Task Switch_Source_Destination_SouldReturns_SameDistance()
    {
        var distance_AMS_IKA = await _sut.GetDistance(new IataCode("AMS"), new IataCode("IKA"));
        distance_AMS_IKA.Should().NotBeNull();
        
        var distance_IKA_AMS = await _sut.GetDistance(new IataCode("AMS"), new IataCode("IKA"));
        distance_IKA_AMS.Should().NotBeNull();

        distance_AMS_IKA.Distance.Should().Be(distance_IKA_AMS.Distance);
    }

    [Fact]
    public async Task Should_Calculate_CorrectDistance()
    {
        var distance = await _sut.GetDistance(new IataCode("AMS"), new IataCode("IKA"));
        distance.Should().NotBeNull();
        distance.Distance.Should().Be(2533.09);
    }
}