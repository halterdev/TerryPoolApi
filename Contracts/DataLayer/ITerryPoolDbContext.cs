using Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DataLayer
{
    public interface ITerryPoolDbContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
