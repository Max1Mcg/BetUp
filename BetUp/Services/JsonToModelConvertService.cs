using BetUp.Models;
using BetUp.Services.IServices;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace BetUp.Services
{
    public class JsonToModelConvertService: IJsonToModelConvertService
    {
        public void FillMatchModel(ref MatchModel jsonResult, string response)
        {
            JToken responseObject = JToken.Parse(response);
            if (responseObject.Type == JTokenType.Array)
            {
                var jsonArray = JArray.Parse(response);
                jsonResult.OddsPlayer1.JsonValue = Convert.ToDouble(jsonArray.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString());
                jsonResult.OddsPlayer2.JsonValue = Convert.ToDouble(jsonArray.SelectToken(jsonResult.OddsPlayer2.JsonPath)?.ToString());
                jsonResult.Player1Name.JsonValue = Convert.ToString(jsonArray.SelectToken(jsonResult.Player1Name.JsonPath)?.ToString());
                jsonResult.Player2Name.JsonValue = Convert.ToString(jsonArray.SelectToken(jsonResult.Player2Name.JsonPath)?.ToString());
            }
            else if (responseObject.Type == JTokenType.Object)
            {
                var jsonObject = JObject.Parse(response);
                jsonResult.OddsPlayer1.JsonValue = Convert.ToDouble(jsonObject.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString());
                jsonResult.OddsPlayer2.JsonValue = Convert.ToDouble(jsonObject.SelectToken(jsonResult.OddsPlayer2.JsonPath)?.ToString());
                jsonResult.Player1Name.JsonValue = Convert.ToString(jsonObject.SelectToken(jsonResult.Player1Name.JsonPath)?.ToString());
                jsonResult.Player2Name.JsonValue = Convert.ToString(jsonObject.SelectToken(jsonResult.Player2Name.JsonPath)?.ToString());
            }
        }
    }
}
