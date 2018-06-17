using Entities.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Teams
{
    public interface ITeamRepository
    {
        Task<List<Team>> Get();
    }
}
