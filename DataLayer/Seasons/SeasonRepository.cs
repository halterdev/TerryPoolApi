using Contracts.DataLayer;
using Contracts.DataLayer.Seasons;
using Entities.Seasons;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Seasons
{
    public class SeasonRepository : ISeasonRepository
    {
        private ITerryPoolDbContext _database;

        public SeasonRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task<List<Season>> Get()
        {
            return await _database.Seasons.ToListAsync();
        }

        public async Task<Season> InsertAsync(Season season)
        {
            _database.Seasons.Add(season);

            await _database.SaveChangesAsync();

            return season;
        }
    }
}
