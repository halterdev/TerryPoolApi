using Contracts.DataLayer;
using Contracts.DataLayer.Users;
using Entities.Users;

namespace DataLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private ITerryPoolDbContext _database;

        public UserRepository(ITerryPoolDbContext database)
        {
            _database = database;
        }

        public int Insert(User user)
        {
            _database.Users.Add(user);

            SaveChanges();

            return user.Id;
        }

        private void SaveChanges()
        {
            _database.SaveChanges();
        }
    }
}
