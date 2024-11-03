using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace APIRecicheck.APIRecicheck.Test.ApiTests
{
    public class UserUpdateTests : IClassFixture<WebApplicationFactory<APIRecicheck.Program>>
    {

        private readonly HttpClient _cliente;

        public UserUpdateTests(WebApplicationFactory<APIRecicheck.Program> factory)
        {
            _cliente = factory;
        }

        [Fact]
        public async Task UpdateProfile_ShouldReturnOk_WhenValidDataProvided()
        {
            var user = new { Username = "Leandro", Password = "123456" };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var loginResponse = await _client.PostAsync("/api/auth/login", content);
            var token = JObject.Parse(await loginResponse.Content.ReadAsStringAsync())["token"].Value<string>();

            var updatedData = new { Username = "LeandroUpdated" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedData), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Put, "/api/user/profile");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.Content = updateContent;
            var response = await _client.SendAsync(request);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
