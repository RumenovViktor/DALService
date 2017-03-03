namespace Data.DataContext
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    using DTOs.Models;
    using Migrations;
    public class DALServiceDataContext : DbContext, IDALServiceDataContext
    {
        public DALServiceDataContext() 
            : base("ConnectWebsite")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DALServiceDataContext, Configuration>());
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Sector> Sectors { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<File> Files { get; set; }

        public IDbSet<Experience> Experience { get; set; }

        public IDbSet<Position> Positions { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public virtual DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges() // TODO: Check if its the best way.
        {
            return base.SaveChanges();
        }
    }
}
