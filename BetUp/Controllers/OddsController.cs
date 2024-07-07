using BetUp.DbModels;
using Microsoft.AspNetCore.Mvc;
using BetUp.DbContexts;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.Json;
using System;
using BetUp.Models;
using BetUp.Helpers;
using BetUp.Services;
using Microsoft.Extensions.Configuration;
using BetUp.Services.IServices;
using BetUp.Repositories.IRepositories;
using BetUp.Repositories;
using QuartzApp.Jobs;
using System.Diagnostics;

namespace WebApiBetsBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OddsController : ControllerBase
    {
        private IGenerateModelService<PariBetClient> _generateModelParibetService;
        private IGenerateModelService<WinlineClient> _generateModelWinlineService;
        private readonly ISaveModelService _saveModelService;
        //TODO for test repository
        private readonly IBaseRepository<Match> _baseRepository;
        public OddsController(
            IGenerateModelService<PariBetClient> generateModelService,
            IGenerateModelService<WinlineClient> generateModelWinlineService,
            ISaveModelService saveModelService,
            IBaseRepository<Match> baseRepository)
        {
            _generateModelParibetService = generateModelService;
            _generateModelWinlineService = generateModelWinlineService;
            _saveModelService = saveModelService;
            _baseRepository = baseRepository;
        }

        //TEST1
        [Route("[action]")]
        [HttpPost]
        public async Task<object> TEST()
        {
            try
            {
                await _baseRepository.Create(new Match { LocalTeam1 = null});
                return Ok(new object());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PARI
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddPariMatchAsync()
        {
            try
            {
                /*var matchModels = await _generateModelParibetService.GetMatchFromRequestAsync();
                _saveModelService.AddModels(matchModels);*/
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Winline
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddWinlineMatchAsync()
        {
            try
            {
                /*var matchModels = await _generateModelWinlineService.GetMatchFromRequestAsync();
                _saveModelService.AddModels(matchModels);*/
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // FON.BET
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddFonbetMatchAsync()
        {
            try
            {
                //var matchModel = await _generateModelWinlineService.GetMatchFromRequestAsync(null);
                //_saveModelService.AddModel(matchModel);
                //return Ok(matchModel);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // LEON
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddLeonMatchAsync()
        {
            try
            {
                //var matchModel = await _generateModelWinlineService.GetMatchFromRequestAsync(null);
                //_saveModelService.AddModel(matchModel);
                //return Ok(matchModel);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // LigaStavok
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddLigaStavokMatchAsync()
        {
            try
            {
                //var matchModel = await _generateModelWinlineService.GetMatchFromRequestAsync(null);
                //_saveModelService.AddModel(matchModel);
                //return Ok(matchModel);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // OlympBet
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddOlympBetMatchAsync()
        {
            try
            {
                //var matchModel = await _generateModelWinlineService.GetMatchFromRequestAsync(null);
                //_saveModelService.AddModel(matchModel);
                //return Ok(matchModel);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("[action]")]
        [HttpGet]
        public async Task<object> GetMatchAsync(Guid id)
        {
            try
            {
                return _saveModelService.GetModel(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}