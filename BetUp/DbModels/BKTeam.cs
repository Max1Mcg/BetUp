using BetUp.CommonInterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetUp.DbModels
{
    public class BKTeam : BaseObject
    {
        public string ForeignTeamId { get; set; }
        public string TeamName { get; set; }
        //public BK Bk { get; set; }
        //public Guid BkId { get; set; }
    }
}
