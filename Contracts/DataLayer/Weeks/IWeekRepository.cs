using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Weeks
{
    public interface IWeekRepository
    {
        Task<List<Week>> Get(int seasonId);
    }
}
