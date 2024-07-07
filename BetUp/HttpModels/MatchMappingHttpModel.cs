using BetUp.DbModels;

namespace BetUp.HttpModels
{
    public class MatchMappingHttpModel
    {
        public Guid InternalMatchId { get; set; }
        public Guid ExternalMatchId { get; set; }
    }
}
