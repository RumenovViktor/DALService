using Models;
using Models.Dashboard;
using Models.Profile;
using System.Collections;
using System.Collections.Generic;

namespace LocalApplicationServices.ProfileManagement.Contracts
{
    public interface IProfileManager
    {
        Profile GetUserProfileInfo(string email);

        CompanyProfile GetCompanyProfile(long companyId);

        UserDashboardProfile GetUserDashboardProfile(long userId);
    }
}
