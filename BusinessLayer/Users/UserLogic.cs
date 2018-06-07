using Contracts.BusinessLayer.Users;
using Contracts.DataLayer.Users;
using Entities.Users;

namespace BusinessLayer.Users
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Register(UserDto newUser)
        {
            User user = ConvertUserDtoToUser(newUser);

            _userRepository.Insert(user);

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
