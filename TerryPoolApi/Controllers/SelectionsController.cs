using Contracts.DataLayer.Users;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly IUpdateUserSelectionService _updateUserSelectionService;

        public SelectionsController(IUpdateUserSelectionService updateUserSelectionService)
        {
            _updateUserSelectionService = updateUserSelectionService;
        }

        [HttpPost]
        [Authorize]
        [Route("add")]
        public async Task Add(UserSelectionDto selectionDto)
        {
            await _updateUserSelectionService.Add(ConvertUserSelectionDtoToEntity(selectionDto));
        }

        private UserSelection ConvertUserSelectionDtoToEntity(UserSelectionDto dto)
        {
            UserSelection us = new UserSelection()
            {
                Id = dto.Id,
                UserId = Convert.ToInt32(User.Claims.ToList()[1].Value),
                TeamId = dto.TeamId,
                WeekId = dto.WeekId
            };

            return us;
        }
    }
}