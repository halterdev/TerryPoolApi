using BusinessLayer.Helpers;
using Contracts.BusinessLayer.Users;
using Contracts.DataLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            newUser.Token = GenerateToken(user.Id, user.Email);

            return newUser;
        }

        public async Task<UserDto> Login(UserDto user)
        {
            User loggedInUser = await _userRepository.GetByEmail(user.Email);

            if (loggedInUser != null)
            {
                string hashedPassword = PasswordHasher.Hash(user.Password);

                if (PasswordHasher.Verify(user.Password, hashedPassword))
                {
                    // hashes match
                    user.LoginCode = Constants.LOGIN_CODE_SUCCESS;
                }
                else
                {
                    // wrong password
                    user.LoginCode = Constants.LOGIN_CODE_INCORRECT_PASSWORD;
                }
            }
            else
            {
                // email doesn't exist
                user.LoginCode = Constants.LOGIN_CODE_EMAIL_DOES_NOT_EXIST;
            }

            if(user.LoginCode == Constants.LOGIN_CODE_SUCCESS)
            {
                user.Token = GenerateToken(loggedInUser.Id, loggedInUser.Email);
            }

            return user;
        }

        public string GenerateToken(int userId, string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("auT68Dff3RtcHe34"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, userId.ToString())
            };

            var token = new JwtSecurityToken("http://localhost:4200",
              "http://localhost:4200",
              claims: claims,
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
                Password = PasswordHasher.Hash(userDto.Password)
            };

            return user;
        }
    }
}
