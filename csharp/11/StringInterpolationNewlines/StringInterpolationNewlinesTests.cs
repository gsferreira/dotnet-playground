using FluentAssertions;

namespace StringInterpolationNewlines;

public class StringInterpolationNewlinesTests
{
    [Fact]
    public void Example()
    {
        var players = new Player[] {
            new("Pepe", 39),
            new("Vitinha", 22),
            new("Uribe", 31)
        };

        var text = $"The oldest player is {
                players.MaxBy(player => player.Age).Name
            }.";

        text.Should().Be("The oldest player is Pepe.");
    }
}

public record Player(string Name, int Age);