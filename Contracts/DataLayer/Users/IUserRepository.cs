using Entities.Users;

namespace Contracts.DataLayer.Users
{
    public interface IUserRepository
    {
        int Insert(User user);
    }
}
