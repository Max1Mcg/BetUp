using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.HttpModels;
using BetUp.Repositories.IRepositories;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalInternalMappingController : ControllerBase
    {
        private ITeamMappingRepository _teamMappingRepository { get; set; }
        private IBaseRepository<BaseObject> _baseRepository { get; set; }
        public ExternalInternalMappingController(ITeamMappingRepository teamMappingRepository,
            IBaseRepository<BaseObject> baseRepository) {
            _teamMappingRepository = teamMappingRepository;
            _baseRepository = baseRepository;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task TeamMapping(TeamMappingHttpModel httpModel)
        {
            //TODO replace to service
            var internalTeam = _baseRepository.GetById<Team>(httpModel.InternalTeamId);
            var externalTeam = _baseRepository.GetById<BKTeam>(httpModel.ExternalTeamId);
            var entityMapping = new TeamMapping {BKTeamId = externalTeam.Id, TeamId = internalTeam.Id };            
            await _teamMappingRepository.Create(entityMapping);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task MatchMapping(MatchMappingHttpModel httpModel)
        {
            //TODO replace to service
            var internalTeam = _baseRepository.GetById<Match>(httpModel.InternalMatchId);
            var externalTeam = _baseRepository.GetById<BKMatch>(httpModel.ExternalMatchId);
            var entityMapping = new MatchMapping { BKMatchId = externalTeam.Id, MatchId = internalTeam.Id };
            await _baseRepository.Create(entityMapping);
        }
    }
}