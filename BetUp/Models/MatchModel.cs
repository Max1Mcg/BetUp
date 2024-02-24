using System.Text.Json.Serialization;

namespace BetUp.Models
{
    public class MatchModel
    {
        //сделать PlayerN как структуру
        public JsonSingleElement<string> Player1Name { get; set; }
        public JsonSingleElement<string> Player2Name { get; set; }
        public JsonSingleElement<double> OddsPlayer1 { get; set; }
        public JsonSingleElement<double> OddsPlayer2 { get; set; }
        public MatchModel() { }
    }
}
