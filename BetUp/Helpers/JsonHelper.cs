using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BetUp.Helpers
{
    public class JsonHelper
    {
        private string testJson = @"
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
                    ""lng"": ""81.1496""
                  }
            }
        }";


        public T GetPropertyValue<T>(string path) where T : class
        {
            JObject jsonObject = JObject.Parse(testJson);
            var jToken = jsonObject.First.Root;

            var resultJToken = GetJTokenByPath(jToken, path);

            return resultJToken.Value<T>();
        }

        private JToken GetJTokenByPath(JToken jToken, string path)
        {
            var propertyName = path.Split('.').FirstOrDefault();
            if (string.IsNullOrEmpty(propertyName)) return jToken;

            var value = jToken.SelectToken(propertyName);
            if (value == null) return jToken;

            if (propertyName == path) return value;

            return GetJTokenByPath(value, path.Substring(propertyName.Length+1));
        }
    }
}