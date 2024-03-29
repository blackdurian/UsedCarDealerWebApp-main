﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.FunctionalTests.Web;
using Xunit;

namespace Microsoft.UsedCarDealerWeb.FunctionalTests.WebRazorPages;

[Collection("Sequential")]
public class HomePageOnGet : IClassFixture<TestApplication>
{
    public HomePageOnGet(TestApplication factory)
    {
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; }

    [Fact]
    public async Task ReturnsHomePageWithProductListing()
    {
        // Arrange & Act
        var response = await Client.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Contains("Honda City", stringResponse);
    }
}
