using Models;

namespace LocalApplicationServices.ProfileManagement.Contracts
{
    public interface IProfileManager
    {
        Profile GetUserProfileInfo(string email);

        CompanyProfile GetCompanyProfile(string companyName);
    }
}
