using TechTalk.SpecFlow;

namespace Poc.SpecFlow.ServeRest.Steps;

[Binding]
public sealed class UsersSteps
{
    [Given(@"I access the users route http://localhost:3001/usuarios")]
    public void GivenIAccessTheUsersRoute()
    {
        Console.WriteLine("to implement");
    }

    [Then(@"I should have only 1 registered users")]
    public void ThenIShouldHaveOnlyOneRegisteredUsers()
    {
        Console.WriteLine("to implement");
    }

    [StepDefinition(@"should be admin")]
    public void AndShouldBeAdmin()
    {
        Console.WriteLine("to implement");
    }

    [StepDefinition(@"your name should be Fulano da Silva")]
    public void AndYourNameShouldBeFulanoDaSilva()
    {
        Console.WriteLine("implements");
    }
}
