using Contracts.DataLayer;
using Contracts.DataLayer.Users;
using Entities.Users;
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

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }
    }
}
