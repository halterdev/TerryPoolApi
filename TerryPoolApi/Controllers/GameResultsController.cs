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
    public class GameResultsController : ControllerBase
    {
        private readonly IAddGameResultService _addGameResultService;

        public GameResultsController(IAddGameResultService addGameResultService)
        {
            _addGameResultService = addGameResultService;
        }

        [Route("upsert")]
        [HttpPost]
        [Authorize]
        public async Task<List<GameDto>> Upsert(List<GameDto> games)
        {
            List<GameResult> gameResults = GetGameResultsFromGameDtos(games);

            await _addGameResultService.Upsert(gameResults, games[0].WeekId);

            return games;
        }

        private List<GameResult> GetGameResultsFromGameDtos(List<GameDto> gameDtos)
        {
            List<GameResult> gameResults = new List<GameResult>();

            foreach(GameDto gameDto in gameDtos)
            {
                GameResult gr = new GameResult()
                {
                    GameId = gameDto.Id,
                    AwayScore = gameDto.AwayScore,
                    HomeScore = gameDto.HomeScore,
                    Game = new Game()
                    {
                        Id = gameDto.Id,
                        AwayTeamId = gameDto.AwayTeam.Id,
                        HomeTeamId= gameDto.HomeTeam.Id,
                        WeekId = gameDto.WeekId
                    }
                };

                gameResults.Add(gr);
            }

            return gameResults;
        }
    }
}