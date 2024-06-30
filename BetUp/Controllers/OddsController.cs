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

namespace WebApiBetsBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OddsController : ControllerBase
    {
        private IGenerateModelService<PariBetClient> _generateModelParibetService;
        private IGenerateModelService<WinlineClient> _generateModelWinlineService;
        private readonly ISaveModelService _saveModelService;
        public OddsController(
            IGenerateModelService<PariBetClient> generateModelService,
            IGenerateModelService<WinlineClient> generateModelWinlineService,
            ISaveModelService saveModelService)
        {
            _generateModelParibetService = generateModelService;
            _generateModelWinlineService = generateModelWinlineService;
            _saveModelService = saveModelService;
        }

        //PARI
        [Route("[action]")]
        [HttpPost]
        public async Task<object> AddPariMatchAsync()
        {
            try
            {
                var matchModels = await _generateModelParibetService.GetMatchFromRequestAsync();
                _saveModelService.AddModels(matchModels);
                return Ok(matchModels);
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
                var matchModels = await _generateModelWinlineService.GetMatchFromRequestAsync();
                _saveModelService.AddModels(matchModels);
                return Ok(matchModels);
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