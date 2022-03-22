using FluentAssertions;
using Xunit;

namespace AnonymousTypesWithExpression;

public class AnonymousTypesWithExpressionTests
{
    [Fact]
    public void WhenUseWith_ThenPropertiesAreCopied()
    {
        var portugal = new { Name = "Portugal", IsoCode = "PRT", Continent = "Europe" };

        var spain = portugal with { Name = "Spain", IsoCode = "ESP" };
        
        spain.Name.Should().Be("Spain");
        spain.Continent.Should().Be("Europe");
    }
}