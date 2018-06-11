using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Users
{
    public interface IUserLogic
    {
        Task<UserDto> Register(UserDto newUser);
    }
}
