using Contracts.BusinessLayer.Teams;
using Contracts.DataLayer.Teams;
using Entities.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Teams
{
    public class TeamManagementService : ITeamManagementService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamManagementService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<List<Team>> Get()
        {
            return await _teamRepository.Get();
        }
    }
}
