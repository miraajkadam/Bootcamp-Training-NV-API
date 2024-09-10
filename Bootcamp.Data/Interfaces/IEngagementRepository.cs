﻿
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Interfaces
{
    public interface IEngagementRepository
    {
        IQueryable<AllEngagementsResponse> GetAllEngagements();
        void AddEngagement(Engagement data);
    }
}
