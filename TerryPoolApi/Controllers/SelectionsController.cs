using Contracts.BusinessLayer.Users;
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
        private readonly IGetUserSelectionService _getUserSelectionService;
        private readonly IUpdateUserSelectionService _updateUserSelectionService;

        public SelectionsController(IGetUserSelectionService getUserSelectionService,
            IUpdateUserSelectionService updateUserSelectionService)
        {
            _getUserSelectionService = getUserSelectionService;
            _updateUserSelectionService = updateUserSelectionService;
        }

        [HttpPost]
        [Authorize]
        [Route("upsert")]
        public async Task Upsert(UserSelectionDto selectionDto)
        {
            await _updateUserSelectionService.Upsert(ConvertUserSelectionDtoToEntity(selectionDto));
        }

        [HttpGet]
        [Authorize]
        [Route("get/{weekId}")]
        public async Task<UserSelectionDto> Get(int weekId)
        {
            UserSelection selection = await _getUserSelectionService.Get(weekId,
                Convert.ToInt32(User.Claims.ToList()[1].Value));

            if(selection == null)
            {
                return null;
            }

            UserSelectionDto dto = ConvertUserSelectionToDto(selection);

            return dto;
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

        private UserSelectionDto ConvertUserSelectionToDto(UserSelection userSelection)
        {
            UserSelectionDto usDto = new UserSelectionDto()
            {
                Id = userSelection.Id,
                TeamId = userSelection.TeamId,
                WeekId = userSelection.WeekId
            };

            return usDto;
        }
    }
}