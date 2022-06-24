using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using Poc.SpecFlow.ServeRest.Helpers;
using Newtonsoft.Json;

namespace Poc.SpecFlow.ServeRest.Steps;

[Binding]
public sealed class LoginStep
{
    private Uri? loginRoute;
    private HttpResponseMessage Response { get; set; } = null!;
    private static readonly HttpClient client = new HttpClient();

    [Given(@"I access the route (.*)")]
    public void GivenIAccessTheRoute(string route)
    {
        loginRoute = new Uri(route);
    }

    [When(@"I pass the (.*) and (.*) password")]
    public async Task WhenIPassTheEmailAndPassword(string email, string password)
    {
        var body = new Dictionary<string, string>
        {
            { "email", email },
            { "password", password }
        };
        var data = JsonConvert.SerializeObject(body);

        var payload = new StringContent(
            data,
            Encoding.UTF8,
            "application/json"
        );

        Response = await client.PostAsync(loginRoute, payload);
    }

    [Then(@"I should get a token for authentication")]
    public async Task ThenIShouldGetATokenForAuthentication()
    {
        var res = await Response.Content.ReadAsStringAsync();
        var body = JObject.Parse(res);

        Assert.That.Contains(res, "Login realizado com sucesso");
        Assert.That.Contains(body["authorization"].ToString(), "Bearer");
    }
}
