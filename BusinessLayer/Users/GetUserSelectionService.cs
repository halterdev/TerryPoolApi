using Contracts.BusinessLayer.Users;
using Contracts.DataLayer.Users;
using Entities.Users;
using System.Threading.Tasks;

namespace BusinessLayer.Users
{
    public class GetUserSelectionService : IGetUserSelectionService
    {
        private readonly IUserSelectionRepository _userSelectionRepository;

        public GetUserSelectionService(IUserSelectionRepository userSelectionRepository)
        {
            _userSelectionRepository = userSelectionRepository;
        }

        public async Task<UserSelection> Get(int weekId, int userId)
        {
            return await _userSelectionRepository.Get(weekId, userId);
        }
    }
}
