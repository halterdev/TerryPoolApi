using Entities.Seasons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Seasons
{
    public interface ISeasonManagementService
    {
        Task<Season> Add(Season season);
        Task<List<Season>> Get();
    }
}
