using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Users
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
    }
}
