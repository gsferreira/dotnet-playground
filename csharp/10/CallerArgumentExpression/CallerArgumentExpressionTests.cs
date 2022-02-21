using System;
using System.Runtime.CompilerServices;
using FluentAssertions;
using Xunit;

namespace CallerArgumentExpression;

public class CallerArgumentExpressionTests
{
    [Fact]
    public void GivenAnOddNumber_WhenVerify_ThenNoExceptionIsThrown()
    {
        var action = () => VerifyIsOddNumber(1);
        action.Should().NotThrow<Exception>();
    }

    [Fact]
    public void GivenAVariableWithAnEvenNumber_WhenVerify_ThenArgumentExceptionIsThrownWithVariableName()
    {
        const int myNumber = 2;
        var action = () => VerifyIsOddNumber(myNumber);
        action.Should().Throw<ArgumentException>()
            .WithMessage("myNumber");
    }

    [Fact]
    public void GivenAnEvenNumber_WhenVerify_ThenArgumentExceptionIsThrownWithValue()
    {
        var action = () => VerifyIsOddNumber(10);
        action.Should().Throw<ArgumentException>()
            .WithMessage("10");
    }

    [Fact]
    public void GivenAnExpressionReturningEvenNumber_WhenVerify_ThenArgumentExceptionIsThrownWithValue()
    {
        var action = () => VerifyIsOddNumber(4 * 2);
        action.Should().Throw<ArgumentException>()
            .WithMessage("4 * 2");
    }

    private void VerifyIsOddNumber(int value, [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value % 2 is 0)
            throw new ArgumentException(paramName);
    }
}