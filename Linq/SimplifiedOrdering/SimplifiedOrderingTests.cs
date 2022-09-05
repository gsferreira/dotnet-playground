using FluentAssertions;
namespace SimplifiedOrdering;

public class SimplifiedOrderingTests
{
    [Fact]
    public void OrderAscendingUsingLinq()
    {
        IEnumerable<string> names =
            new[] { "Guilherme", "Ferreira" }.ToList();

        // Instead of
        //      names.OrderBy(x => x);
        // You can use Simplified Ordering 👇 
        var ascending
            = names.Order();

        ascending.Should().BeInAscendingOrder();
    }
    
    [Fact]
    public void OrderDescendingUsingLinq()
    {
        IEnumerable<string> names =
            new[] { "Guilherme", "Ferreira" }.ToList();

        // Instead of
        //      names.OrderByDescending(x => x);
        // You can use Simplified Ordering 👇
        var descending
            = names.OrderDescending();
        
        descending.Should().BeInDescendingOrder();
    }
}