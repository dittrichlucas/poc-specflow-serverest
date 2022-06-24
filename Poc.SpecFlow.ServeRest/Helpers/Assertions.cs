using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poc.SpecFlow.ServeRest.Helpers;

public static class Assertions
{
    public static bool Contains(this Assert assert, string actual, string expect)
    {
        if (actual.Contains(expect))
            return default;

        throw new AssertFailedException($"expected {actual} contain {expect}");
    }
}
