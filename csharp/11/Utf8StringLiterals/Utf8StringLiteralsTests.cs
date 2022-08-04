using FluentAssertions;

namespace Utf8StringLiterals;

public class Utf8StringLiteralsTests
{
    [Test]
    public void BeforeCSharp11()
    {
        var u8Bytes = System.Text.Encoding.UTF8.GetBytes("ABC");
        u8Bytes.Should().BeEquivalentTo(new[] { 65, 66, 67 });
    }
    
    [Test]
    public void WithCSharp11()
    {
        ReadOnlySpan<byte> u8Span = "ABC"u8;
        u8Span.ToArray().Should().BeEquivalentTo(new[] { 65, 66, 67 });
    }
}