using Entities.Seasons;
using System.Threading.Tasks;

namespace Contracts.DataLayer.Seasons
{
    public interface ISeasonRepository
    {
        Task<Season> InsertAsync(Season season);
    }
}
