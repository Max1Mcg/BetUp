using BetUp.HttpClients.Interfaces;
using BetUp.Models;
using BetUp.Services;
using BetUp.Services.IServices;
using Microsoft.Extensions.Configuration;

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
    public async Task<List<MatchModel>> GetMatches()
    {
        var clientUrl = _configuration.GetSection("BookmakerUrl").GetSection("Winline").Value;
        var response = await _client.GetAsync(clientUrl);
        var responseBody = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        //TODO подумать как взять массив матчей
        var matchModels = new List<MatchModel>();
        var matchModel = new MatchModel()
        {
            OddsPlayer1 = new JsonSingleElement<double>() { JsonPath = "events.[0].markets.[0].rows.[1].cells.[1].value" },
            OddsPlayer2 = new JsonSingleElement<double>() { JsonPath = "events.[0].markets.[0].rows.[1].cells.[1].value" },
            Player1Name = new JsonSingleElement<string>() { JsonPath = "events.[0].markets.[0].rows.[0].cells.[1].caption" },
            Player2Name = new JsonSingleElement<string>() { JsonPath = "events.[0].markets.[0].rows.[0].cells.[3].caption" }
        };
        _jsonToModelConvertService.FillMatchModel(ref matchModel, responseBody);
        return matchModels;
    }
}