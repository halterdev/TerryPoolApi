using Contracts.DataLayer;
using Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class TerryPoolDbContext : DbContext, ITerryPoolDbContext
    {
        public TerryPoolDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
