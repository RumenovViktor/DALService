using Models;
using System.Collections.Generic;

namespace LocalApplicationServices
{
    public interface IDashboardManager
    {
        IList<UserSuitiblePosition> GetSuitiblePositions(string sectorId, string countryId, string userId);
    }
}
