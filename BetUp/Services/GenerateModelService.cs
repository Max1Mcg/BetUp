using BetUp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using System.Net;
using BetUp.Services.IServices;
using BetUp.HttpClients.Interfaces;

namespace BetUp.Services
{
    public class GenerateModelService<T>: IGenerateModelService<T> where T: IClient
    {
        private IJsonToModelConvertService _jsonToModelConvertService;
        private readonly T _client;

        public GenerateModelService(
            IJsonToModelConvertService jsonToModelConvertService,
            T client )
        {
            _jsonToModelConvertService = jsonToModelConvertService;
            _client = client;
        }

        public async Task<List<MatchModel>> GetMatchFromRequestAsync()
        {
            string mockJson = @"
        {
            ""id"": 1,
            ""name"": ""Leanne Graham"",
            ""username"": ""Bret"",
            ""email"": ""Sincere@april.biz"",
            ""address"": {
                  ""street"": ""Kulas Light"",
                  ""suite"": ""Apt. 556"",
                  ""city"": ""Gwenborough"",
                  ""zipcode"": ""92998-3874"",
                  ""geo"": {
                    ""lat"": ""-37.3159"",
                    ""lng"": 81.1496
                  }
            },
            ""matches"":[
                {""p1"": ""navi"", ""p2"": ""g2"", ""o1"": 1.5},
                {""p1"": ""bb"", ""p2"": ""gg"", ""o1"": 1.25, ""o2"": 3.75}
            ]
        }";

            //var matches = await _client.GetMatches();

            var mockMatchPath = "matches";

            //TODO считывать из конфигов, чтобы пути можно было настраивать из конфигурации
            var matchModels = new List<MatchModel>();
            var mockAttributesPaths = new Dictionary<string, string>();
            mockAttributesPaths.Add("OddsPlayer1", "o1");
            mockAttributesPaths.Add("OddsPlayer2", "o2");
            mockAttributesPaths.Add("NamePlayer1", "p1");
            mockAttributesPaths.Add("NamePlayer2", "p2");

            var matchesCount = _jsonToModelConvertService.GetArrayLength(mockMatchPath, mockJson);

            MatchModel mockModel;

            for (int i = 0; i < matchesCount; i++)
            {
                mockModel = new MatchModel()
                {
                    OddsPlayer1 = new JsonSingleElement<double>() { JsonPath = $"matches[{i}].{mockAttributesPaths["OddsPlayer1"]}" },
                    OddsPlayer2 = new JsonSingleElement<double>() { JsonPath = $"matches[{i}].{mockAttributesPaths["OddsPlayer2"]}" },
                    NamePlayer1 = new JsonSingleElement<string>() { JsonPath = $"matches[{i}].{mockAttributesPaths["NamePlayer1"]}" },
                    NamePlayer2 = new JsonSingleElement<string>() { JsonPath = $"matches[{i}].{mockAttributesPaths["NamePlayer2"]}" }
                };
                _jsonToModelConvertService.FillMatchModel(ref mockModel, mockJson);
                matchModels.Add(mockModel);
            }
            return matchModels;
        }
    }
}
