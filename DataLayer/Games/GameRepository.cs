using Contracts.DataLayer;
using Contracts.DataLayer.Games;
using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly ITerryPoolDbContext _database;

        public GameRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task<List<Game>> Get(int seasonId, int week)
        {
            return await _database.Games.Where(g => g.SeasonId == seasonId && g.Week == week).ToListAsync();
        }

        public async Task Insert(Game game)
        {
            await _database.Games.AddAsync(game);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
