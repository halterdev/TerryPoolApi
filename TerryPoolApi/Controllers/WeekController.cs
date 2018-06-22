using Contracts.BusinessLayer.Weeks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekController : ControllerBase
    {
        private readonly IWeekManagementService _weekManagementService;

        public WeekController(IWeekManagementService weekManagementService)
        {
            _weekManagementService = weekManagementService;
        }

        [HttpGet]
        [Authorize]
        [Route("get/{seasonId}")]
        public async Task<List<WeekDto>> Get(int seasonId)
        {
            List<Week> weeks = await _weekManagementService.Get(seasonId);

            List<WeekDto> dtos = new List<WeekDto>();

            foreach(Week week in weeks)
            {
                dtos.Add(MapWeekEntityToWeekDto(week));
            }

            return dtos;
        }

        private WeekDto MapWeekEntityToWeekDto(Week week)
        {
            WeekDto weekDto = new WeekDto()
            {
                Id = week.Id,
                SeasonId = week.SeasonId,
                WeekNum = week.WeekNum
            };

            return weekDto;
        }
    }
}