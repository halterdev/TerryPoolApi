using Entities.Seasons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Seasons
{
    public interface ISeasonRepository
    {
        Task<List<Season>> Get();

        Task<Season> InsertAsync(Season season);
    }
}
