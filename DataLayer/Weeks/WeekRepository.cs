using Contracts.DataLayer;
using Contracts.DataLayer.Weeks;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Weeks
{
    public class WeekRepository : IWeekRepository
    {
        private readonly ITerryPoolDbContext _database;

        public WeekRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task<List<Week>> Get(int seasonId)
        {
            return await _database.Weeks.Where(w => w.SeasonId == seasonId).ToListAsync();
        }
    }
}
