using Contracts.BusinessLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public object Endoding { get; private set; }

        private IUserLogic _userLogic;

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [Route("/token")]
        [HttpGet]
        public IActionResult Create()
        {
            return new ObjectResult(GenerateToken("test"));
            //if (IsValidUserAndPasswordCombination(username, password))
              //  return new ObjectResult(GenerateToken(username));
            //return BadRequest();
        }

        [Route("register")]
        [HttpPost]
        public async Task<UserDto> Register(UserDto user)
        {
            await _userLogic.Register(user);

            return user;
        }

        private string GenerateToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a secret that needs to be at least 16 characters long"));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(JwtRegisteredClaimNames.Email, "john.doe@blinkingcaret.com")
            };

            var token = new JwtSecurityToken(
                issuer: "your app",
                audience: "the client of your app",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}