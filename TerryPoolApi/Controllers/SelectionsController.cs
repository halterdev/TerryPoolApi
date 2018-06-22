using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("add")]
        public async Task Add(UserSelectionDto selectionDto)
        {

        }
    }
}