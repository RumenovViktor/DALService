using DTOs.Models;
using Models;
using System.Collections.Generic;

namespace LocalApplicationServices.ProfileManagement.Contracts
{
    public interface IProfileManager
    {
        // TODO: Not its place!!!
        IList<SkillsDto> GetMatchedSkills(string name);

        Profile GetUserProfileInfo(string email);

        CompanyProfile GetCompanyProfile(string companyName);
    }
}
