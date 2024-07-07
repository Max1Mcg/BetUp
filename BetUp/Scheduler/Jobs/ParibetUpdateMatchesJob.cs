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
                if (!_baseRepository.GetAll<BKMatch>().Any(e => e.ForeignId == v.MatchId.JsonValue))
                    await _baseRepository.Create(new BKMatch { ForeignId = v.MatchId.JsonValue});
                if (!_baseRepository.GetAll<BKTeam>().Any(e => e.ForeignTeamId == v.Player1Id.JsonValue))
                    await _baseRepository.Create(new BKTeam { ForeignTeamId = v.Player1Id.JsonValue, TeamName = v.NamePlayer1.JsonValue });
                if (!_baseRepository.GetAll<BKTeam>().Any(e => e.ForeignTeamId == v.Player2Id.JsonValue))
                    await _baseRepository.Create(new BKTeam { ForeignTeamId = v.Player2Id.JsonValue, TeamName = v.NamePlayer2.JsonValue });
            }

            //await _mappingValidator.MatchMappingExistValidator(matchModels);
            //await _mappingValidator.TeamMappingExistValidator(matchModels);
            await _mappingValidator.MappingExistValidator(matchModels);
            //Для оставшихся по мапингу матчей определяем матч, затем по мапингу команду куда складывать коэффициенты
        }
    }
}