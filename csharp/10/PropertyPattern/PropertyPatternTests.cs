using System;
using Xunit;

namespace PropertyPattern;

public class PropertyPatternTests
{
    [Fact]
    public void GivenNoteWithShortTitle_WhenValidate_ThenReturnsInvalid()
    {
        var note = new Note()
        {
            Title = "Hi",
            Content = "Hello world"
        };

        var (isValid, reason) = Validate(note);

        Assert.False(isValid);
        Assert.Equal("Title should be 5 to 50 char long", reason);
    }

    [Fact]
    public void GivenNoteWithLongTitle_WhenValidate_ThenReturnsInvalid()
    {
        var note = new Note()
        {
            Title =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
            Content = "Hello world"
        };

        var (isValid, reason) = Validate(note);

        Assert.False(isValid);
        Assert.Equal("Title should be 5 to 50 char long", reason);
    }

    [Fact]
    public void GivenNoteWithoutContent_WhenValidate_ThenReturnsInvalid()
    {
        var note = new Note()
        {
            Title = "Hello World!",
        };

        var (isValid, reason) = Validate(note);

        Assert.False(isValid);
        Assert.Equal("Content is required", reason);
    }

    [Fact]
    public void GivenNullNote_WhenValidate_ThenThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Validate(null!));
    }

    [Fact]
    public void GivenWellFormedNote_WhenValidate_ThenIsValid()
    {
        var note = new Note()
        {
            Title = "Hello World!",
            Content = "This is a welcome note"
        };

        var (isValid, reason) = Validate(note);

        Assert.True(isValid);
        Assert.Empty(reason);
    }

    private static (bool isValid, string reason) Validate(Note note)
        => note switch
        {
            { Title.Length: < 5 } or { Title.Length: > 50 } => (false, "Title should be 5 to 50 char long"),
            { Content: null } => (false, "Content is required"),
            null => throw new ArgumentNullException(nameof(note)),
            _ => (true, "")
        };
}