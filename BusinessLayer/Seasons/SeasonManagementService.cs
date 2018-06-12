﻿using Contracts.BusinessLayer.Seasons;
using Contracts.DataLayer.Seasons;
using Entities.Seasons;
using System.Threading.Tasks;

namespace BusinessLayer.Seasons
{
    public class SeasonManagementService : ISeasonManagementService
    {
        private ISeasonRepository _seasonRepository;

        public SeasonManagementService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<Season> Add(Season season)
        {
            await _seasonRepository.InsertAsync(season);

            return season;
        }
    }
}
