using BetUp.DbContexts;
using BetUp.DbModels;
using BetUp.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BetUp.Repositories.IRepositories
{
    public interface IMatchRepository: IBaseRepository<Match>
    {

        Task<Match> GetMatch(Guid id);

        //Task AddMatch(Match matchModel);
    }
}
