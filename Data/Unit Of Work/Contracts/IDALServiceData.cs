using Data.Repository;
using DTOs.Models;

namespace Data.Unit_Of_Work
{
    public interface IDALServiceData
    {
        IRepository<User> Users { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Sector> Sectors { get; }

        IRepository<Company> Companies { get; }
    }
}
