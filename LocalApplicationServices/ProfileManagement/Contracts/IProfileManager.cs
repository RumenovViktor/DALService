using Models;
using Models.Profile;
using System.Collections;
using System.Collections.Generic;

namespace LocalApplicationServices.ProfileManagement.Contracts
{
    public interface IProfileManager
    {
        Profile GetUserProfileInfo(string email);

        CompanyProfile GetCompanyProfile(long companyId);

        IList<UserSuitiblePosition> GetSuitiblePositions(string sectorId, string countryId, string userId);
    }
}
