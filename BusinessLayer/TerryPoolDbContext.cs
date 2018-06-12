using Contracts.DataLayer;
using Entities.Seasons;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TerryPoolDbContext : DbContext, ITerryPoolDbContext
    {
        public TerryPoolDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
