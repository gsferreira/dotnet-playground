using System.Diagnostics.CodeAnalysis;

namespace RequiredMembers;

public class User
{
    public User() { }
    
    [SetsRequiredMembers]
    public User(string email)
    {
        Email = email;
    }
    
    public required string Email { get; init; }
    public string? Name { get; init; }
    public DateOnly? Birthday { get; set; }
}