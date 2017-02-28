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

        public CompanyProfile GetCompanyProfile(string companyName)
        {
            var companyProfile = dalServiceData.Companies.FindEntity(x => x.Name == companyName);

            if (companyProfile == null)
            {
                throw new ArgumentException();
            }

            return new CompanyProfile(companyProfile.Email, companyProfile.Name, "Bulgaria");
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
