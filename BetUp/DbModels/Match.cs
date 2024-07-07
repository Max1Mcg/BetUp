using BetUp.CommonInterfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetUp.DbModels
{
    public partial class Match : BaseObject
    {
        public double? Player1Odds { get; set; }
        public double? Player2Odds { get; set; }
        public Team LocalTeam1 { get; set; }
        public Guid LocalTeam1Id { get; set; }
        public Team LocalTeam2 { get; set; }
        public Guid LocalTeam2Id { get; set; }

        public DateTime? Time { get; set; }

    }
}
