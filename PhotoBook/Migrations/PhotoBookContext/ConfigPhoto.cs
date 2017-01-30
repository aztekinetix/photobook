namespace PhotoBook.Migrations.PhotoBookContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigPhoto : DbMigrationsConfiguration<PhotoBook.DBContexts.PhotoBookContext>
    {
        public ConfigPhoto()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\PhotoBookContext";
        }

        protected override void Seed(PhotoBook.DBContexts.PhotoBookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
