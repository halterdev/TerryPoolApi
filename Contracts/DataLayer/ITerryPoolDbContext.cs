using Entities;
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
        DbSet<GameResult> GameResults { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserSelection> UserSelections { get; set; }
        DbSet<Week> Weeks { get; set; }

        Task<int> SaveChangesAsync();
    }
}
