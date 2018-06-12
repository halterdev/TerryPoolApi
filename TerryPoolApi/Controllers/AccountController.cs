using Contracts.BusinessLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

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

        //[Route("/token")]
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    //return new ObjectResult(GenerateToken("test"));
        //    //if (IsValidUserAndPasswordCombination(username, password))
        //      //  return new ObjectResult(GenerateToken(username));
        //    //return BadRequest();
        //}

        [Route("register")]
        [HttpPost]
        [Authorize]
        public async Task<UserDto> Register(UserDto user)
        {
            //var claims = User.Claims.ToList();
            //var test = claims[1].Value;

            await _userManagementService.Register(user);

            return user;
        }
    }
}