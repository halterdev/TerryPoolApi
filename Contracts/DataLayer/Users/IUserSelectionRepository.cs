using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Users
{
    public interface IUserSelectionRepository
    {
        Task Insert(UserSelection userSelection);

        Task<UserSelection> Get(int weekId, int userId);

        Task<int> SaveChangesAsync();
    }
}
