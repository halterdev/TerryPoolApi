using Contracts.BusinessLayer.Games;
using Contracts.DataLayer.Games;
using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Games
{
    public class AddGameService : IAddGameService
    {
        private readonly IGameRepository _gameRepository;

        public AddGameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task Add(List<Game> games)
        {
            foreach(Game game in games)
            {
                await _gameRepository.Insert(game);
            }

            await _gameRepository.SaveChangesAsync();
        }
    }
}
