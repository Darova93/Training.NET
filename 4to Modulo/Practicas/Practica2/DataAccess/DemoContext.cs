using DataAccess.Configurations;
using DataAccess.Entities;
using System.Data.Entity;

namespace DataAccess
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("EntityFramework")
        {
            Database.SetInitializer<DemoContext>(new DropCreateDatabaseAlways<DemoContext>());
            //Database.SetInitializer<DemoContext>(new MigrateDatabaseToLatestVersion<DemoContext, Migrations.Configuration>());
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Asignation> Asignations { get; set; }

        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new AsignationConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());
        }
    }
}
