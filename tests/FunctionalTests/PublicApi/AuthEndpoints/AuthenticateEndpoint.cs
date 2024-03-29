﻿//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Microsoft.UsedCarDealerWeb.ApplicationCore.Constants;
//using Microsoft.UsedCarDealerWeb.FunctionalTests.PublicApi;
//using Microsoft.UsedCarDealerWeb.PublicApi.AuthEndpoints;
//using Xunit;

//namespace Microsoft.UsedCarDealerWeb.FunctionalTests.Web.Controllers;

//[Collection("Sequential")]
//public class AuthenticateEndpoint : IClassFixture<TestApiApplication>
//{
//    JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

//    public AuthenticateEndpoint(TestApiApplication factory)
//    {
//        Client = factory.CreateClient();
//    }

//    public HttpClient Client { get; }

//    [Theory]
//    [InlineData("demouser@myusedcar.com", AuthorizationConstants.DEFAULT_PASSWORD, true)]
//    [InlineData("demouser@myusedcar.com", "badpassword", false)]
//    [InlineData("baduser@myusedcar.com", "badpassword", false)]
//    public async Task ReturnsExpectedResultGivenCredentials(string testUsername, string testPassword, bool expectedResult)
//    {
//        var request = new AuthenticateRequest()
//        {
//            Username = testUsername,
//            Password = testPassword
//        };
//        var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
//        var response = await Client.PostAsync("api/authenticate", jsonContent);
//        response.EnsureSuccessStatusCode();
//        var stringResponse = await response.Content.ReadAsStringAsync();
//        var model = stringResponse.FromJson<AuthenticateResponse>();

//        Assert.Equal(expectedResult, model.Result);
//    }
//}
