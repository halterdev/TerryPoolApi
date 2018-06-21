using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Games
{
    public interface IRetrieveGameService
    {
        Task<List<Game>> Get(int seasonId, int week);
    }
}
