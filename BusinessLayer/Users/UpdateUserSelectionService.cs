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

        public async Task Upsert(UserSelection userSelection)
        {
            UserSelection existingSelection = 
                await _userSelectionRepository.Get(userSelection.WeekId, userSelection.UserId);

            if(existingSelection == null)
            {
                // user's first pick for this week
                await _userSelectionRepository.Insert(userSelection);
            }
            else
            {
                // updating a pick
                existingSelection.TeamId = userSelection.TeamId;
            }

            await _userSelectionRepository.SaveChangesAsync();
        }
    }
}
