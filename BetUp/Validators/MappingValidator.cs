using BetUp.CommonInterfaces;
using BetUp.DbModels;
using BetUp.Models;
using MarketPlace.Repositories.Interfaces;

namespace BetUp.Validators
{
    public class MappingValidator: IMappingValidator
    {
        public IBaseRepository<BaseObject> _baseRepository;
        public MappingValidator(IBaseRepository<BaseObject> baseRepository) {
            _baseRepository = baseRepository;
        }
        public async Task MappingExistValidator(List<MatchModel> matchModels)
        {
            for (int i = 0; i < matchModels.Count; i++)
            {
                var bkMatchGuid = _baseRepository.GetAll<BKMatch>().FirstOrDefault(e => e.ForeignId == matchModels[i].MatchId.JsonValue)?.Id;
                var isMappingExist = _baseRepository.GetAll<MatchMapping>().Any(e => e.BKMatchId == bkMatchGuid);
                var bkTeam1 = _baseRepository.GetAll<BKTeam>().FirstOrDefault(e => e.ForeignTeamId == matchModels[i].Player1Id.JsonValue)?.Id;
                var bkTeam2 = _baseRepository.GetAll<BKTeam>().FirstOrDefault(e => e.ForeignTeamId == matchModels[i].Player2Id.JsonValue)?.Id;
                var isMapping1Exist = _baseRepository.GetAll<TeamMapping>().Any(e => e.BKTeamId == bkTeam1);
                var isMapping2Exist = _baseRepository.GetAll<TeamMapping>().Any(e => e.BKTeamId == bkTeam2);
                if (!isMapping1Exist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для команды с внешним Id = {matchModels[i].Player1Id.JsonValue} не добавлен", IsSended = false });
                }

                if (!isMapping2Exist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для команды с внешним Id = {matchModels[i].Player2Id.JsonValue} не добавлен", IsSended = false });
                }
                if (!isMappingExist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для матча с внешним Id = {matchModels[i].MatchId.JsonValue} не добавлен", IsSended = false });
                }
                if (!isMapping1Exist || !isMapping2Exist || !isMappingExist)
                {
                    matchModels.RemoveAt(i);
                    i--;
                }
            }
        }

        //Плохо т.к. если удалить всё в первом методе, то уведомления не создадутся во 2м
        /*public async Task MatchMappingExistValidator(List<MatchModel> matchModels)
        {
            for (int i = 0; i < matchModels.Count; i++)
            {
                var bkMatchGuid = _baseRepository.GetAll<BKMatch>().FirstOrDefault(e => e.ForeignId == matchModels[i].MatchId.JsonValue)?.Id;
                var isMappingExist = _baseRepository.GetAll<MatchMapping>().Any(e => e.BKMatchId == bkMatchGuid);
                if (!isMappingExist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для матча с внешним Id = {matchModels[i].MatchId.JsonValue} не добавлен", IsSended = false });
                    matchModels.RemoveAt(i);
                    i--;
                }
            }
        }

        public async Task TeamMappingExistValidator(List<MatchModel> matchModels)
        {
            for (int i = 0; i < matchModels.Count; i++)
            {
                var bkTeam1 = _baseRepository.GetAll<BKTeam>().FirstOrDefault(e => e.ForeignTeamId == matchModels[i].Player1Id.JsonValue)?.Id;
                var bkTeam2 = _baseRepository.GetAll<BKTeam>().FirstOrDefault(e => e.ForeignTeamId == matchModels[i].Player2Id.JsonValue)?.Id;
                var isMapping1Exist = _baseRepository.GetAll<TeamMapping>().Any(e => e.BKTeamId == bkTeam1);
                var isMapping2Exist = _baseRepository.GetAll<TeamMapping>().Any(e => e.BKTeamId == bkTeam2);
                if (!isMapping1Exist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для команды с внешним Id = {matchModels[i].Player1Id.JsonValue} не добавлен", IsSended = false });
                }

                if (!isMapping2Exist)
                {
                    await _baseRepository.Create(new Notification { Message = $"Мапинг для команды с внешним Id = {matchModels[i].Player2Id.JsonValue} не добавлен", IsSended = false });
                }

                if(isMapping1Exist || isMapping2Exist)
                {
                    matchModels.RemoveAt(i);
                    i--;
                }

            }
        }*/
    }
}