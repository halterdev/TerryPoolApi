using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Users
{
    public interface IUserSelectionRepository
    {
        Task Insert(UserSelection userSelection);

        Task<int> SaveChangesAsync();
    }
}
