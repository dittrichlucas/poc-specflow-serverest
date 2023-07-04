using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Poc.SpecFlow.ServeRest.Steps;

[Binding]
public sealed class UsersSteps
{
    private HttpResponseMessage Response { get; set; } = null!;
    private static readonly HttpClient Client = new HttpClient();
    private Uri url { get; set; } = null!;

    [Given(@"I access the users route (.*)")]
    public async Task GivenIAccessTheUsersRoute(string baseUrl)
    {
        url = new Uri(baseUrl);
        Response = await Client.GetAsync(url);
    }

    [Given(@"that the user with ID (.*) exists")]
    public async Task GivenThatExistUserWithId(string expect)
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);
        var actual = parseData["usuarios"][0]["_id"]; // TODO: verificar uma forma mais elegante de acessar o valor da prop dentro do objeto (GetValue?)

        Assert.AreEqual(expect, actual);
    }

    [When(@"I list the user with ID (.*)")]
    public async Task WhenIListUserWithID(string id)
    {
        var urlRes = Path.Combine(url.ToString(), id);
        Response = await Client.GetAsync(urlRes);
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

    [Then(@"the status code should be (.*)")]
    public void ThenTheStatusCodeShouldBe(int expect)
    {
        var actual = (int)Response.StatusCode;

        Assert.AreEqual(expect, actual);
    }

    [Then(@"the returned object should not be empty")]
    public async Task ThenTheReturnedObjectShouldNotBeEmpty()
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);

        Assert.IsNotNull(parseData);
    }

    [StepDefinition(@"the (.*) field should be equal to the passed ID")]
    public async Task AndTheIDFieldShouldBeEqualPassedID(string field)
    {
        var content = await Response.Content.ReadAsStringAsync();
        var actual = JObject.Parse(content);

        var actualUrl = Response?.RequestMessage?.RequestUri;
        var expectId = actualUrl?.Segments.LastOrDefault();
        var actualId = actual[field];

        Assert.AreEqual(expectId, actualId);
    }

    [StepDefinition(@"the name field should be (.*)")]
    public async Task AndTheNameFieldShouldBeFulanoDaSilva(string expect)
    {
        var data = await Response.Content.ReadAsStringAsync();
        var parseData = JObject.Parse(data);
        var actual = parseData["nome"]; // TODO: verificar uma forma mais elegante de acessar o valor da prop dentro do objeto (GetValue?)

        Assert.AreEqual(expect, actual);
    }
}
