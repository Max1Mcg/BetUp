using BetUp.Models;
using BetUp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace BetUp.Services
{
    public class JsonToModelConvertService: IJsonToModelConvertService
    {
        //TODO перенести в сервис
        public int GetArrayLength(string arrayPath, string json)
        {
            JToken responseObject = JToken.Parse(json);
            if (responseObject.Type == JTokenType.Array)
            {
                var jsonArray = JArray.Parse(json);
                var token = jsonArray.SelectToken(arrayPath);
                return token.Count();
            }
            else if (responseObject.Type == JTokenType.Object)
            {
                var jsonObject = JObject.Parse(json);
                var token = jsonObject.SelectToken(arrayPath);
                return  token.Count();
            }
            return 0;
        }

        public void FillMatchModel(ref MatchModel jsonResult, string response)
        {
            JToken responseObject = JToken.Parse(response);
            if (responseObject.Type == JTokenType.Array)
            {
                var jsonArray = JArray.Parse(response);
                jsonResult.OddsPlayer1.JsonValue = Convert.ToDouble(jsonArray.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString());
                jsonResult.OddsPlayer2.JsonValue = Convert.ToDouble(jsonArray.SelectToken(jsonResult.OddsPlayer2.JsonPath)?.ToString());
                jsonResult.NamePlayer1.JsonValue = Convert.ToString(jsonArray.SelectToken(jsonResult.NamePlayer1.JsonPath)?.ToString());
                jsonResult.NamePlayer2.JsonValue = Convert.ToString(jsonArray.SelectToken(jsonResult.NamePlayer2.JsonPath)?.ToString());
            }
            else if (responseObject.Type == JTokenType.Object)
            {
                var jsonObject = JObject.Parse(response);
                jsonResult.OddsPlayer1.JsonValue = Convert.ToDouble(jsonObject.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString());
                jsonResult.OddsPlayer2.JsonValue = Convert.ToDouble(jsonObject.SelectToken(jsonResult.OddsPlayer2.JsonPath)?.ToString());
                jsonResult.NamePlayer1.JsonValue = Convert.ToString(jsonObject.SelectToken(jsonResult.NamePlayer1.JsonPath)?.ToString());
                jsonResult.NamePlayer2.JsonValue = Convert.ToString(jsonObject.SelectToken(jsonResult.NamePlayer2.JsonPath)?.ToString());
            }
        }
    }
}
