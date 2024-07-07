using BetUp.Models;

namespace BetUp.Validators
{
    public interface IMappingValidator
    {
        /*Task MatchMappingExistValidator(List<MatchModel>matchModels);

        Task TeamMappingExistValidator(List<MatchModel> matchModels);*/
         Task MappingExistValidator(List<MatchModel> matchModels);
    }
}