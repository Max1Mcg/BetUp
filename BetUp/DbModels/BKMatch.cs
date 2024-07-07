using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public class BKMatch: BaseObject
    {
        public double? Player1Odds { get; set; }

        public double? Player2Odds { get; set; }
        public string ForeignId { get; set; }
    }
}
