using Contracts.BusinessLayer.Weeks;
using Contracts.DataLayer.Weeks;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Weeks
{
    public class WeekManagementService : IWeekManagementService
    {
        private readonly IWeekRepository _weekRepository;

        public WeekManagementService(IWeekRepository weekRepository)
        {
            _weekRepository = weekRepository;
        }

        public async Task<List<Week>> Get(int seasonId)
        {
            return await _weekRepository.Get(seasonId);
        }
    }
}
