using Contracts.BusinessLayer.Teams;
using Entities.Teams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamManagementService _teamManagementService;

        public TeamController(ITeamManagementService teamManagementService)
        {
            _teamManagementService = teamManagementService;
        }

        [Route("get")]
        [HttpGet]
        [Authorize]
        public async Task<List<TeamDto>> Get()
        {
            List<Team> teams = await _teamManagementService.Get();

            List<TeamDto> dtos = new List<TeamDto>();

            foreach(Team team in teams)
            {
                dtos.Add(MapTeamEntityToDto(team));
            }

            return dtos;
        }

        private TeamDto MapTeamEntityToDto(Team team)
        {
            TeamDto dto = new TeamDto()
            {
                Id = team.Id,
                City = team.City,
                Nickname = team.Nickname
            };

            return dto;
        }
    }
}