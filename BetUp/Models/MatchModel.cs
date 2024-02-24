using System.Text.Json.Serialization;

namespace BetUp.Models
{
    public class MatchModel
    {
        //сделать PlayerN как структуру
        public JsonSingleElement Player1Name { get; set; }
        public JsonSingleElement Player2Name { get; set; }
        public JsonSingleElement OddsPlayer1 { get; set; }
        public JsonSingleElement OddsPlayer2 { get; set; }
        public MatchModel() { }
        //добавить gettypedcolumnvalue!
    }
}
