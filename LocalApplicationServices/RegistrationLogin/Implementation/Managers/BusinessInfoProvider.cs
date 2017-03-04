namespace LocalApplicationServices.RegistrationLogin
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Data.Unit_Of_Work;
    using Utils;
    using Models.Global;

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
            var profileImage = registeredUser.Files.Select(x => x.FileInputStream).FirstOrDefault();
            var country = dalServiceData.Countries.FindEntity(x => x.CountryId == registeredUser.CountryId);

            if (registeredUser != null)
                basicUserInfo = new BasicUserInfo(registeredUser.UserId, profileImage, registeredUser.Email, registeredUser.FirstName, registeredUser.LastName, 
                                                    Gender.Male, registeredUser.DateOfCreation, new CountryReadModel(country.CountryId, country.NiceName));

            return basicUserInfo;
        }

        public IList<SupportedSector> GetAllSupportedSectors()
        {

            var allSupportedSectorsFromDb = dalServiceData.Sectors.All().ToList();
            var allSupportedSectors = allSupportedSectorsFromDb
                    .Select(x => new SupportedSector(x.Id, x.Name)).ToList();

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