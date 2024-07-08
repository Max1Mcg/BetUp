using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public class BKMatch: BaseObject
    {
        public double? Player1Odds { get; set; }

        public double? Player2Odds { get; set; }
        public string ForeignId { get; set; }
        public BKTeam Team1 { get; set; }
        public BKTeam Team2 { get; set; }
        public Guid Team1Id { get; set; }
        public Guid Team2Id { get; set; }
    }
}
