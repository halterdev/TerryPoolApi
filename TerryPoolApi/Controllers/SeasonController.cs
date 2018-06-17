using Contracts.BusinessLayer.Seasons;
using Entities.Seasons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private ISeasonManagementService _seasonManagementService;

        public SeasonController(ISeasonManagementService seasonManagementService)
        {
            _seasonManagementService = seasonManagementService;
        }

        [Route("add")]
        [HttpPost]
        [Authorize]
        public async Task<Season> Add(SeasonDto season)
        {
            Season s = ConvertSeasonDtoToSeason(season);

            await _seasonManagementService.Add(s);

            return s;
        }

        [Route("get")]
        [HttpGet]
        [Authorize]
        public async Task<List<Season>> Get()
        {
            return await _seasonManagementService.Get();
        }

        private Season ConvertSeasonDtoToSeason(SeasonDto seasonDto)
        {
            return new Season()
            {
                Id = seasonDto.Id,
                Year = seasonDto.Year
            };
        }
    }
}