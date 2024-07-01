using System.Text.Json.Serialization;

namespace BetUp.Models
{
    public class MatchModel
    {
        public JsonSingleElement<string> NamePlayer1 { get; set; }
        public JsonSingleElement<string> NamePlayer2 { get; set; }
        public JsonSingleElement<double> OddsPlayer1 { get; set; }
        public JsonSingleElement<double> OddsPlayer2 { get; set; }
        public JsonSingleElement<string> IdPlayer1 { get; set; }
        public JsonSingleElement<string> IdPlayer2 { get; set; }
        public MatchModel() { }
    }
}
