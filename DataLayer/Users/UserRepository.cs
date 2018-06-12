using Contracts.DataLayer;
using Contracts.DataLayer.Users;
using Entities.Users;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> GetByEmail(string email)
        {
            return await _database.Users.Where(u => u.Email == email).SingleOrDefaultAsync();          
        }
    }
}
