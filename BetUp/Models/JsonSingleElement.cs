namespace BetUp.Models
{
    public class JsonSingleElement
    {
        private string _jsonPath = null!;
        private string _jsonValue = null!;
        public string JsonPath { get { return _jsonPath; } set { _jsonPath = value; } }
        public string JsonValue { get { return _jsonValue; } set { _jsonValue = value; } }
    }
}
