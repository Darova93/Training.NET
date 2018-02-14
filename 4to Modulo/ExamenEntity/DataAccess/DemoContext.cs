using DataAccess.Configurations;
using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("EntityFramework")
        {
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseAlways<DemoContext>());
            //Database.SetInitializer<DemoContext>(new DemoInitializer());
            Database.SetInitializer<DemoContext>(new MigrateDatabaseToLatestVersion<DemoContext, Migrations.Configuration>());
        }

        public DbSet<TaskEF> Tasks { get; set; }
        public DbSet<TagEF> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
        }
    }
}
