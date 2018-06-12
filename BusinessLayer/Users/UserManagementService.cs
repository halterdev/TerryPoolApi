using Contracts.BusinessLayer.Users;
using Contracts.DataLayer.Users;
using Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Users
{
    public class UserManagementService : IUserManagementService
    {
        private IUserRepository _userRepository;

        public UserManagementService(IUserRepository userRepository)
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

        public string GenerateToken(string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("auT68Dff3RtcHe34"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("http://localhost:4200",
              "http://localhost:4200",
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User ConvertUserDtoToUser(UserDto userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = GetPasswordHash(userDto.Password)
            };

            return user;
        }

        private string GetPasswordHash(string password)
        {
            return PasswordHasher.Hash(password);
        }
    }
}
