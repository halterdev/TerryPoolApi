using Contracts.BusinessLayer.Games;
using Entities.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerryPoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IAddGameService _addGameService;
        private readonly IRetrieveGameService _retrieveGameService;

        public GameController(IAddGameService addGameService, IRetrieveGameService retrieveGameService)
        {
            _addGameService = addGameService;
            _retrieveGameService = retrieveGameService;
        }

        [Route("add")]
        [HttpPost]
        [Authorize]
        public async Task Add(List<GameDto> gameDtos)
        {
            List<Game> games = new List<Game>();

            foreach(GameDto dto in gameDtos)
            {
                games.Add(MapGameDtoToGameEntity(dto));
            }

            await _addGameService.Add(games);
        }

        [Route("get/{weekId}")]
        [HttpGet]
        [Authorize]
        public async Task<List<GameDto>> Get(int weekId)
        {
            List<Game> games = await _retrieveGameService.Get(weekId);

            List<GameDto> gameDtos = new List<GameDto>();

            foreach(Game game in games)
            {
                gameDtos.Add(MapGameEntityToGameDto(game));
            }

            return gameDtos;
        }

        private Game MapGameDtoToGameEntity(GameDto gameDto)
        {
            Game game = new Game()
            {
                Id = gameDto.Id,
                WeekId = gameDto.WeekId,
                AwayTeamId = gameDto.AwayTeamId,
                HomeTeamId = gameDto.HomeTeamId
            };

            return game;
        }

        private GameDto MapGameEntityToGameDto(Game game)
        {
            GameDto dto = new GameDto()
            {
                Id = game.Id,
                WeekId = game.WeekId,
                WeekNum = game.Week.WeekNum,
                AwayTeam = new Entities.Teams.TeamDto()
                {
                    Id = game.AwayTeam.Id,
                    City = game.AwayTeam.City,
                    Nickname = game.AwayTeam.Nickname
                },
                HomeTeam = new Entities.Teams.TeamDto()
                {
                    Id = game.HomeTeam.Id,
                    City = game.HomeTeam.City,
                    Nickname = game.HomeTeam.Nickname
                }
            };

            return dto;
        }
    }
}