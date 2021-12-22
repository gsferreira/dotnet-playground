using Xunit;

namespace ConstructorInitializeWithTuples
{
    public class ConstructorInitializeWithTuplesTests
    {
        [Fact]
        public void GivenNoteIsCreated_ThenAllPropertiesAreSet()
        {
            var note = new Note("Hello", "Hello World!");
            
            Assert.Equal("Hello", note.Title);
            Assert.Equal("Hello World!", note.Content);
        }
    }
public class Note
{
    public Note(string title, string content)
        => (Content, Title) = (content, title);

    public string Title { get; }
    public string Content { get; }
}
}