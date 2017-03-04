namespace LocalApplicationServices
{
    using System.Linq;
    using ApplicationServices;
    using Models.Global;
    using Data.Unit_Of_Work;
    using Models;

    public class CommonInfoManager : ICommonInfoManager
    {
        private readonly IDALServiceData dalServiceData;

        public CommonInfoManager(IDALServiceData dalServiceData)
        {
            this.dalServiceData = dalServiceData;
        }

        public ActivityAreaReadModel GetActivityArea()
        {
            var countries = dalServiceData.Countries.All().ToList().Select(x => new CountryReadModel(x.CountryId, x.NiceName)).ToList();
            var sectors = dalServiceData.Sectors.All().ToList().Select(x => new SupportedSector(x.Id, x.Name)).ToList();

            return new ActivityAreaReadModel(countries, sectors);
        }
    }
}
