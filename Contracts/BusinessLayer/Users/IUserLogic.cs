using Entities.Users;

namespace Contracts.BusinessLayer.Users
{
    public interface IUserLogic
    {
        UserDto Register(UserDto newUser);
    }
}
