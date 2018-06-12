using Entities.Users;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Users
{
    public interface IUserManagementService
    {
        Task<UserDto> Register(UserDto newUser);

        string GenerateToken(int userId, string email);
    }
}
