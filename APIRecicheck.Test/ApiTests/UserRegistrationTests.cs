using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Testing;

public class UserRegistrationTests : IClassFixture<WebApplicationFactory<APIRecicheck.Program>>
{
    private readonly HttpClient _client;

    public UserRegistrationTests(WebApplicationFactory<APIRecicheck.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Login_ShouldReturnToken_WhenValidCredentials()
    {
        // Arrange
        var user = new 
        { 
            UserId = 1, 
            Username = "Leandro", 
            Password = "123456", 
            Role = "gerente" 
        };
        var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/auth/login", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        // Assert Status Code
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        // Assert Response Body
        JObject json = JObject.Parse(responseBody);
        json["token"].Value<string>().Should().NotBeNullOrEmpty();
    }
}
