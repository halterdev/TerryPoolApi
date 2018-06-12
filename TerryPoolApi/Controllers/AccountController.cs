using Contracts.BusinessLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public object Endoding { get; private set; }

        private IUserManagementService _userManagementService;

        public AccountController(IUserManagementService userLogic)
        {
            _userManagementService = userLogic;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserDto> Login(UserDto user)
        {
            await _userManagementService.Login(user);

            return user;
        }

        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserDto> Register(UserDto user)
        {
            //var claims = User.Claims.ToList();
            //var test = claims[1].Value;

            await _userManagementService.Register(user);

            return user;
        }
    }
}