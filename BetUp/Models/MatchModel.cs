﻿using System.Text.Json.Serialization;

namespace BetUp.Models
{
    public class MatchModel
    {
        //сделать PlayerN как структуру
        public JsonSingleElement<string> NamePlayer1 { get; set; }
        public JsonSingleElement<string> NamePlayer2 { get; set; }
        public JsonSingleElement<double> OddsPlayer1 { get; set; }
        public JsonSingleElement<double> OddsPlayer2 { get; set; }
        public MatchModel() { }
    }
}
