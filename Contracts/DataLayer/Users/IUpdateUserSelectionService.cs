using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Users
{
    public interface IUpdateUserSelectionService
    {
        Task Upsert(UserSelection userSelection);
    }
}
