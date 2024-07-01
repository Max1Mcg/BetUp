using BetUp.CommonInterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetUp.DbModels
{
    public class BKTeam: BaseObject
    {
        public string ForeignTeamId { get; set; }
        public Team LocalTeam { get; set; }
        public BK Bk { get; set; }
    }
}
