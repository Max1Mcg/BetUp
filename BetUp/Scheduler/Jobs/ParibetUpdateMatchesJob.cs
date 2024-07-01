using BetUp.Services.IServices;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuartzApp.Jobs
{
    public class ParibetUpdateMatchesJob : IJob
    {
        IGenerateModelService<PariBetClient> _generateModelService;
        ISaveModelService _saveModelService;
        public ParibetUpdateMatchesJob(IGenerateModelService<PariBetClient> generateModelService,
            ISaveModelService saveModelService) {
            _generateModelService = generateModelService;
            _saveModelService = saveModelService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            //var matchModels = await _generateModelService.GetMatchFromRequestAsync();
            //await _saveModelService.AddModels(matchModels);
        }
    }
}