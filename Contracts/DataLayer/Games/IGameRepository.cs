using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Games
{
    public interface IGameRepository
    {
        Task<List<Game>> Get(int weekId);
        Task Insert(Game game);

        Task<int> SaveChangesAsync();
    }
}
