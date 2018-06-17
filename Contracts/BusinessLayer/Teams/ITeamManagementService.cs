using Entities.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Teams
{
    public interface ITeamManagementService
    {
        Task<List<Team>> Get();
    }
}
