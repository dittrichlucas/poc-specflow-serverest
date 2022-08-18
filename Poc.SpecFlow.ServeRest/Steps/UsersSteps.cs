using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Poc.SpecFlow.ServeRest.Steps;

[Binding]
public sealed class UsersSteps
{
    private HttpResponseMessage Response { get; set; } = null!;
    private static readonly HttpClient Client = new HttpClient();

    [Given(@"I access the users route (.*)")]
    public async Task GivenIAccessTheUsersRoute(string baseUrl)
    {
        var url = new Uri(baseUrl);
        Response = await Client.GetAsync(url);
    }

    [Then(@"I should have only (.*) registered users")]
    public async Task ThenIShouldHaveOnlyOneRegisteredUsers(int expect)
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);
        var actual = parseData["quantidade"];

        Assert.AreEqual(expect, actual);
    }

    [StepDefinition(@"should be admin")]
    public async Task AndShouldBeAdmin()
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);
        var actual = parseData["usuarios"][0]["administrador"];

        Assert.AreEqual("true", actual);
    }

    [StepDefinition(@"your name should be (.*)")]
    public async Task AndYourNameShouldBeFulanoDaSilva(string expect)
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);
        var actual = parseData["usuarios"][0]["nome"]; // TODO: verificar uma forma mais elegante de acessar o valor da prop dentro do objeto (GetValue?)

        Assert.AreEqual(expect, actual);
    }
}
