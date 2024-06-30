using BetUp.Models;

namespace BetUp.HttpClients.Interfaces
{
    public interface IClient
    {
        Task<string> GetMatches();
    }
}
