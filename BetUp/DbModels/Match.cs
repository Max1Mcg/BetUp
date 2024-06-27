using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public partial class Match: BaseObject
    {
        public string? Player1Name { get; set; }

        public string? Player2Name { get; set; }

        public double? Player1Odds { get; set; }

        public double? Player2Odds { get; set; }

        public DateTime? Time { get; set; }

    }
}
