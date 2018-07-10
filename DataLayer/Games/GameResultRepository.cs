using Contracts.DataLayer;
using Contracts.DataLayer.Games;
using Entities.Games;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Games
{
    public class GameResultRepository : IGameResultRepository
    {
        private readonly ITerryPoolDbContext _database;

        public GameResultRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task Insert(GameResult gameResult)
        {
            await _database.GameResults.AddAsync(gameResult);
        }

        public async Task<GameResult> Get(int weekId, int awayTeamId, int homeTeamId)
        {
            return await _database.GameResults.FirstOrDefaultAsync(gr => gr.Game.WeekId == weekId &&
                gr.Game.AwayTeamId == awayTeamId && gr.Game.HomeTeamId == homeTeamId);
        }

        public async Task<int> SaveChanges()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
