using System;
using System.Linq;
using LocalApplicationServices.ProfileManagement.Contracts;
using Models;
using Data.Unit_Of_Work;
using System.Collections.Generic;

namespace LocalApplicationServices.ProfileManagement.Managers
{
    public class ProfileManager : Base, IProfileManager
    {
        public ProfileManager(IDALServiceData dalServiceData) 
            : base(dalServiceData)
        {
        }

        public IList<SkillsDto> GetMatchedSkills(string name)
        {
            var matchedSkills = dalServiceData.Skills.All().Where(x => x.Name.Contains(name)).ToList().Select(x => new SkillsDto(x.SkillId, x.Name));

            return matchedSkills.ToList();
        }

        public Profile GetUserProfileInfo(string email)
        {
            var userExperience = dalServiceData.Users
                        .FindEntity(x => x.Email == email)
                        .Experience.OrderByDescending(x => x.ExperienceId)
                        .Select(x => new ExperienceViewModel()
                        {
                            Description = x.PositionDiscription,
                            Position = x.PositionName,
                            EndDate = x.ToDate,
                            StartDate = x.FromDate
                        }).ToList();

            return new Profile() { UserExperience = userExperience };
        }
    }
}
