using FluentAssertions;

namespace RequiredMembers;

public class RequiredMembersTests
{
    [Test]
    public void WhenNewUserWithDefaultConstructor_ThenRequiresSetEmail()
    {
        const string expectedEmail = "me@gsferreira.com";
        
        var user = new User()
        {
            Email = expectedEmail
        };
        
        user.Email.Should().Be(expectedEmail);
    }
    
    [Test]
    public void WhenNewUserWithEmailConstructor_ThenDoesNotRequireMemberSet()
    {
        const string expectedEmail = "me@gsferreira.com";
        
        var user = new User(expectedEmail);

        user.Email.Should().Be(expectedEmail);
    }
}
