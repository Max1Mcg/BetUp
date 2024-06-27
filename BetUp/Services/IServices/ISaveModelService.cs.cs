using BetUp.DbModels;
using BetUp.Models;

namespace BetUp.Services.IServices
{
    public interface ISaveModelService
    {
        void AddModels(List<MatchModel> matchModel);
        public Task<Match> GetModel(Guid id);
    }
}
