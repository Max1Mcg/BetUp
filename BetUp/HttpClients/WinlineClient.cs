using BetUp.HttpClients.Interfaces;
using BetUp.Models;
using BetUp.Services;
using BetUp.Services.IServices;
using Microsoft.Extensions.Configuration;
using System.Drawing;

public class WinlineClient : IClient
{
    private readonly HttpClient _client;
    private readonly IJsonToModelConvertService _jsonToModelConvertService;
    private readonly IConfiguration _configuration;
    public WinlineClient(HttpClient client,
        IJsonToModelConvertService jsonToModelConvertService,
        IConfiguration configuration)
    {
        _client = client;
        _jsonToModelConvertService = jsonToModelConvertService;
        _configuration = configuration;
    }
    public async Task<string> GetMatches()
    {
        var clientUrl = _configuration.GetSection("BookmakerUrl").GetSection("Winline").Value;
        var response = await _client.GetAsync(clientUrl);
        var responseBody = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        return responseBody;
    }
}