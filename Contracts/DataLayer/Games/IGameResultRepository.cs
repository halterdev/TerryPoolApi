using Entities.Games;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Games
{
    public interface IGameResultRepository
    {
        Task Insert(GameResult gameResult);

        Task<GameResult> Get(int weekId, int awayTeamId, int homeTeamId);

        Task<int> SaveChanges();
    }
}
