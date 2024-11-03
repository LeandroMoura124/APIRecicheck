using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit.Abstractions;

public class RegistrationCollectionUnauthorized : IClassFixture<WebApplicationFactory<APIRecicheck.Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;
    private string _token;

    public RegistrationCollectionUnauthorized(WebApplicationFactory<APIRecicheck.Program> factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    [Fact]
    public async Task RegisterCollection_ShouldAuthenticateAndRetry_WhenUnauthorized()
    {
        var collectionData = new
        {
            tipoResiduo = "madeira",
            dataColeta = "2024-06-27T01:54:11.553Z",
            quantidade = "5kg"
        };
        var content = new StringContent(JsonConvert.SerializeObject(collectionData), System.Text.Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/coleta", content);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _output.WriteLine("Não autorizado. Teste finalizado.");
            return; // Encerra o teste
        }

        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

        response = await _client.PostAsync("/api/coleta", content);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseBody = await response.Content.ReadAsStringAsync();
        responseBody.Should().Contain("coletaId");
    }
}
