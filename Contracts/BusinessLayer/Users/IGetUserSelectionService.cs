using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Users
{
    public interface IGetUserSelectionService
    {
        Task<UserSelection> Get(int weekId, int userId);
    }
}
