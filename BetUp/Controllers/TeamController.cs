﻿using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.HttpModels;
using MarketPlace.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private IBaseRepository<Team> _baseRepository { get; set; }
        private IBaseRepository<BKTeam> _baseRepository2 { get; set; }

        public TeamController(IBaseRepository<Team> baseRepository,
            IBaseRepository<BKTeam> baseRepository2) {
            _baseRepository = baseRepository;
            _baseRepository2 = baseRepository2;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task AddInternalTeam(InternalMatchHttpModel model)
        {
            _baseRepository.Create(new Team { Name = model.Name});
        }

        /*[Route("[action]")]
        [HttpPost]
        public async Task AddExternalTeam(ExternalTeamHttpModel model)
        {
            _baseRepository2.Create(new BKTeam { TeamName = model.BKName, ForeignTeamId = model.ExternalTeamId, BkId = model.BKId });
        }*/
    }
}
