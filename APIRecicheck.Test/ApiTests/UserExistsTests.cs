using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;

public class UserExistsTests : IClassFixture<WebApplicationFactory<APIRecicheck.Program>>
{
    private readonly HttpClient _cclient;

    public UserDataExistsTests(WebApplicationFactory<APIRecicheck.Program> factory)
    {
        _cclient = factory.CreateClient();
    }

    [Fact]
    public async Task Register_ShouldReturnConflict_WhenUserAlreadyExists()
    {
        // Arrange
        var existingUser = new { Username = "Leandro", Password = "123456", Role = "user" };
        var content = new StringContent(JsonConvert.SerializeObject(existingUser), Encoding.UTF8, "application/json");

        // Act
        var response = await _cclient.PostAsync("/api/auth/register", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
    }

}
