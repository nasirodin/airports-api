using airport_api.Models;
using airport_api.Services;
using FluentAssertions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;

namespace airport_api.test;

public class AirportInfoCacheTest
{
    private readonly AirportInfoCache _sut;
    public AirportInfoCacheTest()
    {
        var opts = Options.Create(new MemoryDistributedCacheOptions());
        var memoryCache = new MemoryDistributedCache(opts);
        _sut = new AirportInfoCache(memoryCache);
    }
    
    [Fact]
    public async Task Set_Get_Test()
    {
        await _sut.Set(TestData.Airports.AMS);
        var actual = await _sut.Get(new IataCode(TestData.Airports.AMS.Iata));
        actual.Should().BeEquivalentTo(TestData.Airports.AMS);
    }
}