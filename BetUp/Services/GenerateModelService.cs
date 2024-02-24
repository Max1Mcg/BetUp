using BetUp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using System.Net;
using BetUp.Services.IServices;

namespace BetUp.Services
{
    public class GenerateModelService: IGenerateModelService
    {
        private IRequestService _requestService;
        private IJsonToModelConvertService _jsonToModelConvertService;

        public GenerateModelService(
            IRequestService requestService,
            IJsonToModelConvertService jsonToModelConvertService) 
        {
            _requestService = requestService;
            _jsonToModelConvertService = jsonToModelConvertService;
        }

        public async Task<MatchModel> GetModelFromRequestAsync<T>(string baseURL)
        {
            var response = await _requestService.GetResponseDataAsync(baseURL);
            JToken responseObject = JToken.Parse(response);
            var jsonResult = new MatchModel() {
                //TODO Работающий пример, остальные члены были тестовые, надо удалить
                OddsPlayer1 = new JsonSingleElement<double>() { JsonPath = "events.[0].markets.[0].rows.[1].cells.[1].value" },
            };
            if (responseObject.Type == JTokenType.Array)
            {
                var jsonArray = JArray.Parse(response);
                _jsonToModelConvertService.FillMatchModel(ref jsonResult, jsonArray: jsonArray);
            }
            else if (responseObject.Type == JTokenType.Object)
            {
                var jsonObject = JObject.Parse(response);
                _jsonToModelConvertService.FillMatchModel(ref jsonResult, jsonObject: jsonObject);
            }
            return jsonResult;
        }
    }
}
