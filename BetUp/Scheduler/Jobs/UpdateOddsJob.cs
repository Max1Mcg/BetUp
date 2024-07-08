using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.Services.IServices;
using BetUp.Validators;
using MarketPlace.Repositories.Interfaces;
using Quartz;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuartzApp.Jobs
{
    public class UpdateOddsJob : IJob
    {
        IBaseRepository<BaseObject> _baseRepository;
        IGenerateModelService<PariBetClient> _generateModelService;
        ISaveModelService _saveModelService;
        IMappingValidator _mappingValidator;
        public UpdateOddsJob(IGenerateModelService<PariBetClient> generateModelService,
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
            //TODO возможно стоит добавить ещё условие на перевод в Active false сюда же
            //TODO подумать как отбирать min/max
            var activeMatches = _baseRepository.GetAll<Match>().Where(m => m.Active);
            var activeMatchesIds = activeMatches.Select(m => m.Id);
            var matchMapping = _baseRepository.GetAll<MatchMapping>().Where(m => activeMatchesIds.Contains(m.MatchId));
            var bkActiveMatchesIds = matchMapping.Select(m => m.BKMatchId);
            var bkActiveMatches = _baseRepository.GetAll<BKMatch>().Where(m => bkActiveMatchesIds.Contains(m.Id));
            foreach (var v in activeMatches)
            {
                var internalTeam1Id = v.LocalTeam1Id;
                var internalTeam2Id = v.LocalTeam2Id;
                var externalTeam1Ids = _baseRepository.GetAll<TeamMapping>().Where(m => m.TeamId == internalTeam1Id).Select(e => e.BKTeamId);
                var externalTeam2Ids = _baseRepository.GetAll<TeamMapping>().Where(m => m.TeamId == internalTeam2Id).Select(e => e.BKTeamId);
                double sumTeam1 = 0;
                double sumTeam2 = 0;
                var countTeam1 = 0;
                var countTeam2 = 0;
                foreach(var t in bkActiveMatches)
                {
                    if (externalTeam1Ids.Contains(t.Team1Id)) {
                        sumTeam1 += t.Player1Odds.Value;
                        countTeam1++;
                    }
                    if (externalTeam1Ids.Contains(t.Team2Id))
                    {
                        sumTeam1 += t.Player2Odds.Value;
                        countTeam1++;
                    }

                    if (externalTeam2Ids.Contains(t.Team1Id))
                    {
                        sumTeam2 += t.Player1Odds.Value;
                        countTeam2++;
                    }
                    if (externalTeam2Ids.Contains(t.Team2Id))
                    {
                        sumTeam2 += t.Player2Odds.Value;
                        countTeam2++;
                    }
                }
                v.Player1Odds = sumTeam1 / countTeam1;
                v.Player2Odds = sumTeam2 / countTeam2;
                await _baseRepository.Update<Match>(v);
            }
        }
    }
}