﻿using Entities.Games;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.BusinessLayer.Games
{
    public interface IAddGameResultService
    {
        Task Upsert(List<GameResult> gameResult, int weekId);
    }
}
