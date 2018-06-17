using Contracts.DataLayer;
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

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
