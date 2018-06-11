using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Contracts.DataLayer
{
    public interface ITerryPoolDbContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
