using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.Services.IServices;
using BetUp.Validators;
using MarketPlace.Repositories.Interfaces;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuartzApp.Jobs
{
    public class ParibetUpdateMatchesJob : IJob
    {
        IBaseRepository<BaseObject> _baseRepository;
        IGenerateModelService<PariBetClient> _generateModelService;
        ISaveModelService _saveModelService;
        IMappingValidator _mappingValidator;
        public ParibetUpdateMatchesJob(IGenerateModelService<PariBetClient> generateModelService,
            ISaveModelService saveModelService,
            IMappingValidator mappingValidator,
            IBaseRepository<BaseObject> baseRepository)
        {
            _generateModelService = generateModelService;
            _saveModelService = saveModelService;
            _mappingValidator = mappingValidator;
            _baseRepository = baseRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var dictionary = new Dictionary<string, string> { 
                { "OddsPlayer1", "markets[0].rows[1].cells[1].value" },
                { "OddsPlayer2", "markets[0].rows[1].cells[2].value" },
                { "NamePlayer1", "team1" },
                { "NamePlayer2", "team2" },
                { "team1Id", "team1Id" },
                { "team2Id", "team2Id" },
                { "Id", "id" }
            };
            var matchModels = await _generateModelService.GetMatchFromRequestAsync("events", dictionary);
            //TODO вынести нижнее в сервис
            foreach (var v in matchModels) {
                if (!_baseRepository.GetAll<BKTeam>().Any(e => e.ForeignTeamId == v.Player1Id.JsonValue))
                    await _baseRepository.Create(new BKTeam { ForeignTeamId = v.Player1Id.JsonValue, TeamName = v.NamePlayer1.JsonValue });
                else
                {
                    var existedTeam = _baseRepository.GetAll<BKTeam>().Single(e => e.ForeignTeamId == v.Player1Id.JsonValue);
                    existedTeam.TeamName = v.NamePlayer1.JsonValue;
                    await _baseRepository.Update<BKTeam>(existedTeam);
                }
                if (!_baseRepository.GetAll<BKTeam>().Any(e => e.ForeignTeamId == v.Player2Id.JsonValue))
                    await _baseRepository.Create(new BKTeam { ForeignTeamId = v.Player2Id.JsonValue, TeamName = v.NamePlayer2.JsonValue });
                else
                {
                    var existedTeam = _baseRepository.GetAll<BKTeam>().Single(e => e.ForeignTeamId == v.Player2Id.JsonValue);
                    existedTeam.TeamName = v.NamePlayer2.JsonValue;
                    await _baseRepository.Update<BKTeam>(existedTeam);
                }
                var t = _baseRepository.GetAll<BKMatch>();
                if (!_baseRepository.GetAll<BKMatch>().Any(e => e.ForeignId == v.MatchId.JsonValue))
                {
                    var team1Id = _baseRepository.GetAll<BKTeam>().Single(e => e.ForeignTeamId == v.Player1Id.JsonValue).Id;
                    var team2Id = _baseRepository.GetAll<BKTeam>().Single(e => e.ForeignTeamId == v.Player2Id.JsonValue).Id;
                    await _baseRepository.Create(new BKMatch { ForeignId = v.MatchId.JsonValue, Team1Id = team1Id, Team2Id = team2Id, Player1Odds = v.OddsPlayer1.JsonValue, Player2Odds = v.OddsPlayer2.JsonValue });
                }
                else
                {
                    var existedTeam = _baseRepository.GetAll<BKMatch>().Single(e => e.ForeignId == v.MatchId.JsonValue);
                    existedTeam.ForeignId = v.MatchId.JsonValue;
                    existedTeam.Player1Odds = v.OddsPlayer1.JsonValue;
                    existedTeam.Player2Odds = v.OddsPlayer2.JsonValue;
                    await _baseRepository.Update<BKMatch>(existedTeam);
                }
            }

            //await _mappingValidator.MatchMappingExistValidator(matchModels);
            //await _mappingValidator.TeamMappingExistValidator(matchModels);
            await _mappingValidator.MappingExistValidator(matchModels);
        }
    }
}