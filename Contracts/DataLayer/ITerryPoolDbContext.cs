using Entities.Games;
using Entities.Seasons;
using Entities.Teams;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Contracts.DataLayer
{
    public interface ITerryPoolDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
