using BetUp.Services.IServices;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuartzApp.Jobs
{
    public class EmailSender : IJob
    {
        IGenerateModelService<PariBetClient> _generateModelService;
        ISaveModelService _saveModelService;
        public EmailSender(IGenerateModelService<PariBetClient> generateModelService,
            ISaveModelService saveModelService) {
            _generateModelService = generateModelService;
            _saveModelService = saveModelService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var matchModels = await _generateModelService.GetMatchFromRequestAsync();
            _saveModelService.AddModels(matchModels);
        }
    }
}