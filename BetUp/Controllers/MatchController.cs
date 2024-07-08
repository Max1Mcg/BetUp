using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.HttpModels;
using MarketPlace.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private IBaseRepository<Match> _baseRepository { get; set; }
        private IBaseRepository<BKMatch> _baseRepository2 { get; set; }

        public MatchController(IBaseRepository<Match> baseRepository,
            IBaseRepository<BKMatch> baseRepository2)
        {
            _baseRepository = baseRepository;
            _baseRepository2 = baseRepository2;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task AddInternalTeam(InternalMatchHttpModel model)
        {
            await _baseRepository.Create(new Match {LocalTeam1Id = model.LocalTeam1Id, LocalTeam2Id = model.LocalTeam2Id, Active = model.IsActive});
        }
    }
}
