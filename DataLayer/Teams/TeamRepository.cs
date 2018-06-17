using Contracts.DataLayer;
using Contracts.DataLayer.Teams;
using Entities.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ITerryPoolDbContext _database;

        public TeamRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task<List<Team>> Get()
        {
            return await _database.Teams.ToListAsync();
        }
    }
}
