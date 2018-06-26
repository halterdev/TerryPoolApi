using Contracts.DataLayer.Users;
using Entities.Users;
using System.Threading.Tasks;

namespace BusinessLayer.Users
{
    public class UpdateUserSelectionService : IUpdateUserSelectionService
    {
        private readonly IUserSelectionRepository _userSelectionRepository;

        public UpdateUserSelectionService(IUserSelectionRepository userSelectionRepository)
        {
            _userSelectionRepository = userSelectionRepository;
        }

        public async Task Add(UserSelection userSelection)
        {
            await _userSelectionRepository.Insert(userSelection);
            await _userSelectionRepository.SaveChangesAsync();
        }
    }
}
