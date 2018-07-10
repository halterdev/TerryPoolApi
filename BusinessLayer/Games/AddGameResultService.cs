using Contracts.BusinessLayer.Games;
using Contracts.DataLayer.Games;
using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Games
{
    public class AddGameResultService : IAddGameResultService
    {
        private readonly IGameResultRepository _gameResultRepository;

        public AddGameResultService(IGameResultRepository gameResultRepository)
        {
            _gameResultRepository = gameResultRepository;
        }

        public async Task Upsert(List<GameResult> gameResults, int weekId)
        {
            foreach(GameResult gameResult in gameResults)
            {
                GameResult existingGameResult = await _gameResultRepository.Get(weekId,
                    gameResult.Game.AwayTeamId, gameResult.Game.HomeTeamId);

                if(existingGameResult == null)
                {
                    // adding result
                    gameResult.Game = null;

                    await _gameResultRepository.Insert(gameResult);
                }
                else
                {
                    // updating a result
                    existingGameResult.AwayScore = gameResult.AwayScore;
                    existingGameResult.HomeScore = gameResult.HomeScore;
                }
            }

            await _gameResultRepository.SaveChanges();
        }
    }
}
