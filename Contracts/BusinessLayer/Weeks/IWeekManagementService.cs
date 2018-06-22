using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Weeks
{
    public interface IWeekManagementService
    {
        Task<List<Week>> Get(int seasonId);
    }
}
