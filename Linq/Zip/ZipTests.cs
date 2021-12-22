using System.Linq;
using Xunit;

namespace Zip;

public class ZipTests
{
    [Fact]
    public void GivenListOfStudents_WhenZipWithSequenceOfNumbers_ThenCombineThem()
    {
        var students = new[] { "Guilherme", "Alexandre" };
        var numbers = Enumerable.Range(1, students.Length);

        var studentNumbers = numbers
            .Zip(students.OrderBy(name => name),
                (number, name) => $"{number}. {name}");

        Assert.Equal("1. Alexandre, 2. Guilherme", string.Join(", ", studentNumbers));
    }
}