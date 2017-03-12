using System;
using System.Collections.Generic;
using Models;
using Data.Unit_Of_Work;
using Executors;
using LocalApplicationServices.ProfileManagement.Contracts;

namespace LocalApplicationServices
{
    public class DashboardManager : Base, IDashboardManager
    {
        public DashboardManager(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public IList<UserSuitiblePosition> GetSuitiblePositions(string sectorIdQuery, string countryIdQuery, string userId)
        {
            int? sectorId = !string.IsNullOrWhiteSpace(sectorIdQuery) ? int.Parse(sectorIdQuery) : (int?)null;
            int? countryId = !string.IsNullOrWhiteSpace(countryIdQuery) ? int.Parse(countryIdQuery) : (int?)null;

            var user = dalServiceData.Users.FindEntity(x => x.Email == userId);

            var matchedPositions = new UserMatchingExecutor(dalServiceData).Match(user, sectorId, countryId);

            return matchedPositions;
        }
    }
}
