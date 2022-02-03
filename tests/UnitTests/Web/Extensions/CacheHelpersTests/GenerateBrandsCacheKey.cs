using Microsoft.UsedCarDealerWeb.Web.Extensions;
using Xunit;

namespace Microsoft.UsedCarDealerWeb.UnitTests.Web.Extensions.CacheHelpersTests;

public class GenerateBrandsCacheKey
{
    [Fact]
    public void ReturnsBrandsCacheKey()
    {
        var result = CacheHelpers.GenerateBrandsCacheKey();

        Assert.Equal("brands", result);
    }
}
