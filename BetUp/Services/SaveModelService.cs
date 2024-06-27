﻿using BetUp.Models;
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
        public void AddModels(List<MatchModel> matchModels)
        {
            _matchRepository.CreateRange(matchModels.Select(matchModel => new Match
            {
                Player1Name = matchModel.Player1Name.JsonValue,
                Player2Name = matchModel.Player2Name.JsonValue,
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