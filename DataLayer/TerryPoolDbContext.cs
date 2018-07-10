using Contracts.DataLayer;
using Entities;
using Entities.Games;
using Entities.Seasons;
using Entities.Teams;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TerryPoolDbContext : DbContext, ITerryPoolDbContext
    {
        public TerryPoolDbContext(DbContextOptions options) : base(options) { }

        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }
        public DbSet<Week> Weeks { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
