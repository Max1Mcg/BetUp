using BetUp.HttpClients.Interfaces;
using BetUp.Models;
using Newtonsoft.Json.Linq;

namespace BetUp.Services.IServices
{
    public interface IGenerateModelService<T>
    {
        Task<List<MatchModel>> GetMatchFromRequestAsync();
    }
}
