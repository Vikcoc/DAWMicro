using System.Data.Entity.Migrations;
using MVCezara.Models;

namespace MVCezara.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MicroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MVCezara.MicroContext";
        }

        protected override void Seed(MicroContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}