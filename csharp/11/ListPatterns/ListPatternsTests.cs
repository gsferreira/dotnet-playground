using FluentAssertions;

namespace ListPatterns;

public class ListPatternsTests
{
    [Theory]
    [InlineData("Hello .NET friends!", ".NET")]
    [InlineData("Hello dear .NET friends!", "dear .NET")]
    [InlineData("bla", "Something else")]
    [InlineData("", "One Empty string element")]
    public async void GivenText_WhenSplit_ThenApplyPatternMatching(string input, string output)
    {
        var words = input.Split(' ');

        byte[] x = "hello"u8.ToArray();

        var result = words switch
        {
            { Length: 0 } => "Empty array",
            [{ Length: 0 }] => "One Empty string element",
            ["Hello", .. string[] somethings, "friends!"] => string.Join(" ", somethings),
            _ => "Something else"
        };

        result.Should().Be(output);
    }

    [Theory]
    [InlineData(new string[] { }, "Empty")]
    [InlineData(new string[] { "e1" }, "Found e1")]
    [InlineData(new string[] { "e1", "e2" }, "Found e1 and e2")]
    [InlineData(new string[] { "e1", "e2", "e3", "e4", "e5" }, "Many found: from e1 to e5")]
    public async void GivenStringCollection_ThenReturnCollectionDescription(string[] input, string output)
    {
        var result = input switch
        {
            [] => "Empty",
            [var a] => $"Found {a}",
            [var a, var b] => $"Found {a} and {b}",
            [var a, .. _, var z] => $"Many found: from {a} to {z}"
        };

        result.Should().Be(output);
    }

    [Fact]
    public void GivenUri_ThenApplyPatternMatchingToSegments()
    {

        var uri = new Uri("http://www.mysite.com/categories/category-a/sub-categories/sub-category-a.html");

        var result = uri.Segments switch
        {
            ["/"] => "Root",
            [_, var single] => single,
            [_, .. string[] entries, _] => string.Join(" > ", entries)
        };

        result.Should().Be("categories/ > category-a/ > sub-categories/");

    }


    [Theory]
    [InlineData(3, 6)]
    [InlineData(10, 3628800)]
    public void GivenNumber_ThenCalculateFactorialUsingListPatterns(int input, int output)
    {

        var values = Enumerable.Range(1, input).ToArray();

        var factorial = Factorial(values);

        factorial.Should().Be(output);


        int Factorial(int[] values)
        {

            return values switch
            {
                [] => 1,
                [.. int[] numbers, int number] => number * Factorial(numbers)

            };
        }
    }



}