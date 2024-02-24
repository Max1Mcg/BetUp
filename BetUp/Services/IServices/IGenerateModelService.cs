using BetUp.Models;
using Newtonsoft.Json.Linq;

namespace BetUp.Services.IServices
{
    public interface IGenerateModelService
    {
        public Task<MatchModel> GetModelFromRequestAsync<T>(string baseURL);
    }
}
