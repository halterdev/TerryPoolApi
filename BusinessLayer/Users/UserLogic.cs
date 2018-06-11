using Contracts.BusinessLayer.Users;
using Contracts.DataLayer.Users;
using Entities.Users;
using System.Threading.Tasks;

namespace BusinessLayer.Users
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Register(UserDto newUser)
        {
            User user = ConvertUserDtoToUser(newUser);

            await _userRepository.InsertAsync(user);

            newUser.Id = user.Id;

            return newUser;
        }

        private User ConvertUserDtoToUser(UserDto userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                Email = userDto.Email
            };

            return user;
        }
    }
}
