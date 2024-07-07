using BetUp.DbModels;

namespace BetUp.HttpModels
{
    public class TeamMappingHttpModel
    {
        public Guid InternalTeamId { get; set; }
        public Guid ExternalTeamId { get; set; }
    }
}
