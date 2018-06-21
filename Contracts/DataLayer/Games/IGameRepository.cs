using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Games
{
    public interface IGameRepository
    {
        Task<List<Game>> Get(int seasonId, int week);
        Task Insert(Game game);

        Task<int> SaveChangesAsync();
    }
}
