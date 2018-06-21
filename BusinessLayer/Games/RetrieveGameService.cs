using Contracts.BusinessLayer.Games;
using Contracts.DataLayer.Games;
using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Games
{
    public class RetrieveGameService : IRetrieveGameService
    {
        private readonly IGameRepository _gameRepository;

        public RetrieveGameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<Game>> Get(int seasonId, int week)
        {
            return await _gameRepository.Get(seasonId, week);
        }
    }
}
