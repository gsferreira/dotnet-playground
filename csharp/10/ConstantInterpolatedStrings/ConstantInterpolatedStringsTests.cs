using Xunit;

namespace ConstantInterpolatedStrings;

public class ConstantInterpolatedStringsTests
{
    [Fact]
    public void GivenConstString_WhenInterpolate_ThenCodeIsValid()
    {
        const string errorCode = "1001";
        const string errorMessage = $"{errorCode} - Invalid username";
        
        Assert.Equal("1001 - Invalid username", errorMessage);
    }
}