using System.Collections.Generic;
using NetDevPL.Infrastructure.Services;

namespace NetDevPLWeb.Features.LearnOnline
{
    public class LearnOnlineSource
    {
        private readonly IJsonReader _repository;

        public LearnOnlineSource(IJsonReader repository)
        {
            _repository = repository;
        }

        public ICollection<Website> GetMasteringTools()
        {
            return _repository.ReadAll<Website>("Features/LearnOnline/toolsMastering.json");
        }

        public ICollection<Website> GetProgrammingChallenges()
        {
            return _repository.ReadAll<Website>("Features/LearnOnline/programmingChallenges.json");
        }
    }
}