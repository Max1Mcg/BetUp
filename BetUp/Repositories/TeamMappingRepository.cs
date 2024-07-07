using BetUp.DbContexts;
using BetUp.DbModels;
using BetUp.Logger.Interfaces;
using BetUp.Repositories.IRepositories;
using MarketPlace.Repositories.Base;

namespace BetUp.Repositories
{
    public class TeamMappingRepository: BaseRepository<TeamMapping>, ITeamMappingRepository
    {
        public TeamMappingRepository(BetUpContext context, ILoggerActions loggerActions)
             : base(context, loggerActions) { }
    }
}
