namespace BetUp.Models
{
    public class JsonSingleElement<T>
    {
        private string _jsonPath = null!;
        private T _jsonValue;
        public string JsonPath { get { return _jsonPath; } set { _jsonPath = value; } }
        public T JsonValue { get { return _jsonValue; } set { _jsonValue = value; } }
    }
}
