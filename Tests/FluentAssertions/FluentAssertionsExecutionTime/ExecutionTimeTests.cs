using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace FluentAssertionsExecutionTime;

public class ExecutionTimeTests
{
    // Reference: https://fluentassertions.com/executiontime

    [Fact]
    public void GivenFastFunction_WhenAssertExecutionTime_ThenSucceed()
    {
        var func = RandomMethod;

        func.ExecutionTime().Should().BeLessThan(20.Milliseconds());

        void RandomMethod()
        {
            // Do nothing
        }
    }

    [Fact]
    public async Task GivenFastAsyncFunction_WhenAssertExecutionTime_ThenSucceed()
    {
        var func = () => Task.Delay(5.Milliseconds());

        await func.Should().CompleteWithinAsync(20.Milliseconds());
    }
}