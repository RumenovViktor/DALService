namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    using DataContext;
    using DTOs.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DALServiceDataContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DALServiceDataContext context)
        {
            //  This method will be called after migrating to the latest version.
            
        }
    }
}
