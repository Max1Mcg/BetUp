using BetUp.Models;
using BetUp.Repositories;
using BetUp.Repositories.IRepositories;
using BetUp.Services.IServices;
using BetUp.DbModels;

namespace BetUp.Services
{
    public class SaveModelService : ISaveModelService
    {
        IMatchRepository _matchRepository;
        public SaveModelService(IMatchRepository matchRepository) {
            _matchRepository = matchRepository;
        }
        public async Task AddModels(List<MatchModel> matchModels)
        {
            await _matchRepository.CreateRange(matchModels.Select(matchModel => new Match
            {
                //Player1Name = matchModel.NamePlayer1.JsonValue,
                //Player2Name = matchModel.NamePlayer2.JsonValue,
                Player1Odds = matchModel.OddsPlayer1.JsonValue,
                Player2Odds = matchModel.OddsPlayer2.JsonValue
            }));
        }

        public async Task<Match> GetModel(Guid id)
        {
            return await _matchRepository.GetMatch(id);
        }
    }
}