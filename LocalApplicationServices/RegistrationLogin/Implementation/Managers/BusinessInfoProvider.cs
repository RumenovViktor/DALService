namespace LocalApplicationServices.RegistrationLogin
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Data.Unit_Of_Work;
    using Utils;
    using System;

    public class BusinessInfoProvider : IBusinessInfoProvider
    {
        private readonly IDALServiceData dalServiceData;

        public BusinessInfoProvider(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public BasicUserInfo GetBasicUserInfo(string email)
        {
            BasicUserInfo basicUserInfo = null;
            var registeredUser = dalServiceData.Users.FindEntity(x => x.Email == email);

            if (registeredUser != null)
                basicUserInfo = new BasicUserInfo(null, registeredUser.Email, registeredUser.FirstName, registeredUser.LastName, Gender.Male);

            return basicUserInfo;
        }

        public IList<SupportedSector> GetAllSupportedSectors()
        {
            var allSupportedSectorsFromDb = dalServiceData.Sectors.All();

            var allSupportedSectors = allSupportedSectorsFromDb
                    .Select(x => new SupportedSector()
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();

            return allSupportedSectors;
        }

        public IList<SupportedCompany> GetCompaniesForSector(int sectorId)
        {
            var companiesForSector = dalServiceData.Sectors
                .FindEntity(x => x.Id == sectorId)
                .Companies
                .Select(x => new SupportedCompany()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return companiesForSector;
        }
    }
}