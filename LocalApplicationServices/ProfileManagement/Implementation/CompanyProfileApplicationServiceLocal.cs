namespace LocalApplicationServices
{
    using System.Linq;

    using ApplicationServices;
    using Models;
    using Data.Unit_Of_Work;
    using DTOs.Models;

    public class CompanyProfileApplicationServiceLocal : Base, ICompanyProfileApplicationService
    {
        public CompanyProfileApplicationServiceLocal(IDALServiceData dalServiceData) : base(dalServiceData) { }

        public AddPosition Execute(AddPosition command)
        {
            dalServiceData.Positions.AddEntity(new Position()
            {
                PositionName = command.PositionName,
                Description = command.PositionDescription
            });

            dalServiceData.Positions.SaveChanges();

            command.PositionId = dalServiceData.Positions.All().Select(x => x.Id).AsEnumerable().Last();
            return command;
        }
    }
}
