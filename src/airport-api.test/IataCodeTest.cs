using airport_api.Models;
using FluentAssertions;

namespace airport_api.test;

public class IataCodeTest
{
    [Fact]
    public void different_references_sameCode_should_beEqual()
    {
        var code1 = new IataCode("AMS");
        var code2 = new IataCode("AMS");
        code1.Equals(code2).Should().BeTrue();
    }
    
    [Fact]
    public void differentCode_should_notEqual()
    {
        var code1 = new IataCode("AMS");
        var code2 = new IataCode("IKA");
        code1.Equals(code2).Should().BeFalse();
    }

    [Theory]
    [InlineData("AMS",true)]
    [InlineData("IKA",true)]
    [InlineData("IKA1",false)]
    [InlineData("IK1",false)]
    [InlineData("IK",false)]
    [InlineData("",false)]
    [InlineData(null,false)]
    public void validate_iataCode(string? code, bool isValid)
    {
        new IataCode(code).IsValid().Should().Be(isValid);
    }
}