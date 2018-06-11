using Contracts.DataLayer;
using Contracts.DataLayer.Users;
using Entities.Users;
using System.Threading.Tasks;

namespace DataLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private ITerryPoolDbContext _database;

        public UserRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public async Task<User> InsertAsync(User user)
        {
            _database.Users.Add(user);

            await _database.SaveChangesAsync();

            return user;
        }
    }
}
