using BetUp.DbContexts;
using BetUp.DbModels;
using BetUp.Logger.Interfaces;
using BetUp.Models;
using BetUp.Repositories.IRepositories;
using MarketPlace.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BetUp.Repositories
{
    public class MatchRepository: BaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(BetUpContext context, ILoggerActions loggerActions)
            : base(context, loggerActions) {}

        public async Task<Match> GetMatch(Guid id)
        {
            return _context.Matches.Where(match => match.Id == id).FirstOrDefault();
        }

        /*public async Task AddMatch(Match matchModel)
        {
            await _context.Matches.AddAsync(matchModel);
            await _context.SaveChangesAsync();
        }*/
    }
}
