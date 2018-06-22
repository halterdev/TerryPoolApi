using Contracts.DataLayer;
using Contracts.DataLayer.Users;

namespace DataLayer.Users
{
    public class UserSelectionRepository : IUserSelectionRepository
    {
        private readonly ITerryPoolDbContext _database;

        public UserSelectionRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }
    }
}
