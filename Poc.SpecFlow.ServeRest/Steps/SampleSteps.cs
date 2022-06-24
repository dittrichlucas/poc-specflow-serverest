using TechTalk.SpecFlow;
using TechTalk.SpecFlow.UnitTestProvider;

namespace Poc.SpecFlow.ServeRest;

[Binding]
public sealed class SampleStep
{
    private readonly IUnitTestRuntimeProvider _unitRuntimeProvider;

    public SampleStep(IUnitTestRuntimeProvider unitTestRuntimeProvider)
    {
        _unitRuntimeProvider = unitTestRuntimeProvider;
    }

    [Given(@"precondition")]
    public void Given()
    {
        _unitRuntimeProvider.TestIgnore("skip");
        throw new NotImplementedException();
    }

    [When(@"action")]
    public void When()
    {
        _unitRuntimeProvider.TestIgnore("skip");
        throw new NotImplementedException();
    }

    [Then(@"testable outcome")]
    public void Then()
    {
        _unitRuntimeProvider.TestIgnore("skip");
        throw new NotImplementedException();
    }
}
