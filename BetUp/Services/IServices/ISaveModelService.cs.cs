using BetUp.DbModels;
using BetUp.Models;

namespace BetUp.Services.IServices
{
    public interface ISaveModelService
    {
        Task AddModels(List<MatchModel> matchModel);
        public Task<Match> GetModel(Guid id);
    }
}
