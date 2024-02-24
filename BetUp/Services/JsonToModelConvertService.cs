using BetUp.Models;
using BetUp.Services.IServices;
using Newtonsoft.Json.Linq;

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
            }
            else if (responseObject.Type == JTokenType.Object)
            {
                var jsonObject = JObject.Parse(response);
                jsonResult.OddsPlayer1.JsonValue = Convert.ToDouble(jsonObject.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString());
            }
        }
    }
}
