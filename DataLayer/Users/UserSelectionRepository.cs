using Contracts.DataLayer;
using Contracts.DataLayer.Users;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Users
{
    public class UserSelectionRepository : IUserSelectionRepository
    {
        private readonly ITerryPoolDbContext _database;

        public UserSelectionRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task Insert(UserSelection userSelection)
        {
            await _database.UserSelections.AddAsync(userSelection);
        }

        public async Task<UserSelection> Get(int weekId, int userId)
        {
            return await _database.UserSelections.Where(u => u.WeekId == weekId && u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
