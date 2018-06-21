using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Games
{
    public interface IAddGameService
    {
        Task Add(List<Game> games);
    }
}
