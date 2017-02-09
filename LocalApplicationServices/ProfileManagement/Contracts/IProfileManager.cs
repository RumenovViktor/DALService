using DTOs.Models;
using Models;
using System.Collections.Generic;

namespace LocalApplicationServices.ProfileManagement.Contracts
{
    public interface IProfileManager
    {
        IList<SkillsDto> GetMatchedSkills(string name);

        Profile GetUserProfileInfo(string email);
    }
}
