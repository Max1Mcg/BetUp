using BetUp.Models;

namespace BetUp.HttpClients.Interfaces
{
    public interface IClient
    {
        Task<List<MatchModel>> GetMatches();
    }
}
