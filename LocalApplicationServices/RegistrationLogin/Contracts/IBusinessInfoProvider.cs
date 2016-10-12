namespace LocalApplicationServices.RegistrationLogin
{
    using System.Collections.Generic;

    using Models;
    
    public interface IBusinessInfoProvider
    {
        BasicUserInfo GetBasicUserInfo(string email);

        IList<SupportedSector> GetAllSupportedSectors();

        IList<SupportedCompany> GetCompaniesForSector(int sectorId);
    }
}
