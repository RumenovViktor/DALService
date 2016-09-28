namespace Data.DataContext
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    using DTOs.Models;

    public class DALServiceDataContext : DbContext, IDALServiceDataContext
    {
        public DALServiceDataContext()
            : base("ConnectWebsite")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public virtual DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override Task<int> SaveChangesAsync() // TODO: Check if its the best way.
        {
            return base.SaveChangesAsync();
        }
    }
}
