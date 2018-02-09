using DataAccessEF.Configurations;
using DataAccessEF.Entities;
using System.Data.Entity;

namespace DataAccessEF
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("EntityFramework")
        {
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseIfModelChanges<DemoContext>());
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseAlways<DemoContext>());

            Database.SetInitializer<DemoContext>(new DemoInitializer());
        }

        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new OptionConfiguration());
            modelBuilder.Configurations.Add(new QuestionTypeConfiguration());
        }
    }
}
