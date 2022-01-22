using System.Linq;
using FluentAssertions;
using Xunit;

namespace xUnitDisplayName;

public class DisplayNameTests
{
    // Underscores will be replaced by whitespaces.
    // That is done because we configured `methodDisplayOptions` with `replaceUnderscoreWithSpace`.
    // Configuration at xunit.runner.json file.
    [Fact]
    public void Given10_WhenMultiplyBy2_ThenGet20()
    {
        var result = 10 * 2;

        result.Should().Be(20);
    }

    // Besides replacing underscores with whitespaces we can replace operator names with matching symbols.
    // So in the following example, we will read "Is 20 > 10".
    // That is done because we configured `methodDisplayOptions` with `useOperatorMonikers`.
    // Configuration at xunit.runner.json file.
    [Fact]
    public void Is_20_gt_10()
    {
        20.Should().BeGreaterThan(10);
    }
    
    // On each Fact, we can provide a custom Display Name.
    // You just need to provide a string as DisplayName in the Fact Attribute.
    [Fact(DisplayName = "Get the max number of an array")]
    public void GivenAnArray_WhenApplyMax_ThenGetThenBiggerOne()
    {
        new[] { 12, 10, 20, 42 }
            .Max()
            .Should()
            .Be(42);
    }
}