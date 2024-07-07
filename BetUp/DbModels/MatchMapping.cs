using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public class MatchMapping : BaseObject
    {
        public BKMatch BKMatch { get; set; }
        public Guid BKMatchId { get; set; }
        public Match Match { get; set; }
        public Guid MatchId { get; set; }
    }
}
