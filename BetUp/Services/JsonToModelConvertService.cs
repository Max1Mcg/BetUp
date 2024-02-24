using BetUp.Models;
using BetUp.Services.IServices;
using Newtonsoft.Json.Linq;

namespace BetUp.Services
{
    public class JsonToModelConvertService: IJsonToModelConvertService
    {
        //сделать 2 разных метода, этот будет только инкапсулировать вызов нужного в зависимости от параметров
        public void FillMatchModel(ref MatchModel jsonResult, JArray jsonArray = null!, JObject jsonObject = null!)
        {
            if (jsonArray != null)
            {
                jsonResult.OddsPlayer1.JsonValue = jsonArray.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString();
            }
            else if (jsonObject != null)
            {
                jsonResult.OddsPlayer1.JsonValue = jsonObject.SelectToken(jsonResult.OddsPlayer1.JsonPath)?.ToString();
            }
        }
    }
}
