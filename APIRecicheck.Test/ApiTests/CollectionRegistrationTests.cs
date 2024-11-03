using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

public class CollectionRegistrationTests : IClassFixture<WebApplicationFactory<APIRecicheck.Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;
    private string _token;

    public CollectionRegistrationTests(WebApplicationFactory<APIRecicheck.Program> factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    private async Task AuthenticateAsync()
    {
        var user = new
        {
            UserId = 1,
            Username = "Leandro",
            Password = "123456",
            Role = "gerente"
        };
        var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/auth/login", content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseBody = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(responseBody);
        _token = json["token"].Value<string>();
    }

    [Fact]
    public async Task RegisterCollection_ShouldAuthenticateAndRetry_WhenUnauthorized()
    {
        
        var collectionData = new
        {
            tipoResiduo = "pedra",
            dataColeta = "2024-06-27T01:54:11.553Z",
            quantidade = "10kg"
        };
        var content = new StringContent(JsonConvert.SerializeObject(collectionData), System.Text.Encoding.UTF8, "application/json");

        
        var response = await _client.PostAsync("/api/coleta", content);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            
            await AuthenticateAsync();

            
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            
            response = await _client.PostAsync("/api/coleta", content);
        }

        _output.WriteLine("Teste Realizado Com Sucesso! Coleta Cadastrada.");

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        
        var responseBody = await response.Content.ReadAsStringAsync();
        responseBody.Should().Contain("coletaId"); 
    }
}
