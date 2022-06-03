using System;
using FluentAssertions;
using Xunit;

namespace RawStringLiterals;

public class RawStringLiteralTests
{
    [Fact]
    public void SimpleLiteral()
    {
        var text = """Hello World!""";

        text.Should().Be("Hello World!");
    }

    [Fact]
    public void LiteralWithDoubleQuotes()
    {
        var text = """You have a message: "Hello World!".""";

        text.Should().Be("You have a message: \"Hello World!\".");
    }

    [Fact]
    public void LiteralWith3DoubleQuoteSets()
    {
        var text = """"You have a message: """Hello World!"""."""";

        text.Should().Be("You have a message: \"\"\"Hello World!\"\"\".");
    }


    [Fact]
    public void MultiLineLiteralWithoutLeadingWhiteSpace()
    {
        var text =
                """
                SELECT Name
                FROM Customers
                WHERE id = @id
                """;

        text.Should().Be($"SELECT Name{System.Environment.NewLine}FROM Customers{System.Environment.NewLine}WHERE id = @id");
    }

    [Fact]
    public void MultiLineLiteralWithLeadingWhiteSpace()
    {
        var text =
                """
                SELECT Name
                FROM Customers
                WHERE id = @id
            """;

        text.Should().Be($"    SELECT Name{System.Environment.NewLine}    FROM Customers{System.Environment.NewLine}    WHERE id = @id");
    }

    [Fact]
    public void Interpolation()
    {
        var name = "Guilherme";
        var text =
                $"""
                Hello { name}!

                Welcome to the Team!
                """;

        text.Should().Be($"Hello Guilherme!{System.Environment.NewLine}{System.Environment.NewLine}Welcome to the Team!");
    }

    [Fact]
    public void InterpolationWithCurlyBracesContent()
    {
        var name = "Guilherme";
        var text =
                $$"""
                Hello {{{ name }}}!

                Welcome to the Team!
                """;

        text.Should().Be($"Hello {{Guilherme}}!{System.Environment.NewLine}{System.Environment.NewLine}Welcome to the Team!");
    }

    [Fact]
    public void InterpolationWith3CurlyBraceSetsContent()
    {
        var name = "Guilherme";
        var text =
                $$$$"""
                Hello {{{{{{{ name }}}}}}}!

                Welcome to the Team!
                """;

        text.Should().Be($"Hello {{{{{{Guilherme}}}}}}!{System.Environment.NewLine}{System.Environment.NewLine}Welcome to the Team!");

    }
    
    [Fact]
    public void InterpolationWith3CurlyBraceSetsAndDoubleQuotes()
    {
        var name = "Guilherme";
        var text =
                $$$$""""
                Hello """{{{{{{{ name }}}}}}}"""!

                Welcome to the Team!
                """";

        text.Should().Be($"Hello \"\"\"{{{{{{Guilherme}}}}}}\"\"\"!{System.Environment.NewLine}{System.Environment.NewLine}Welcome to the Team!");
    }
}