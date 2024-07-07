using System.Text.Json.Serialization;

namespace BetUp.Models
{
    public class MatchModel
    {
        public JsonSingleElement<string> NamePlayer1 { get; set; }
        public JsonSingleElement<string> NamePlayer2 { get; set; }
        public JsonSingleElement<double> OddsPlayer1 { get; set; }
        public JsonSingleElement<double> OddsPlayer2 { get; set; }
        public JsonSingleElement<string> Player1Id { get; set; }
        public JsonSingleElement<string> Player2Id { get; set; }
        public JsonSingleElement<string> MatchId { get; set; }
        public MatchModel() { }
    }
}
