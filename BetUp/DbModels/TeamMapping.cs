using BetUp.CommonInterfaces;

namespace BetUp.DbModels
{
    public class TeamMapping : BaseObject
    {
        //подумать как это будет работать со списком для мапинга
        public BKTeam BKTeam { get; set; }
        public Team Team { get; set; }
        public Guid TeamId { get; set; }
        public Guid BKTeamId { get; set; }
    }
}
