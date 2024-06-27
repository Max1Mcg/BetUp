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
            var matchModels = await _client.GetMatches();
            return matchModels;
        }
    }
}
