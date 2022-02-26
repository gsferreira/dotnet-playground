using FluentAssertions;
using NetEscapades.EnumGenerators;
using Xunit;

namespace Libraries.NetEscapades.EnumGenerators;

[EnumExtensions]
public enum Colors
{
    White,
    Blue,
    Black
}

public class EnumGeneratorsTests
{
    [Fact]
    public void GivenAnEnum_WhenConvertingToString_ThenFasterResult()
    {
        Colors.Black.ToStringFast()
            .Should().Be("Black");
    }

    [Fact]
    public void GivenNameOfANonExistingColor_WhenVerifyIfIsDefined_ThenIsFalse()
    {
        ColorsExtensions.IsDefined("Green")
            .Should().BeFalse();
    }
}