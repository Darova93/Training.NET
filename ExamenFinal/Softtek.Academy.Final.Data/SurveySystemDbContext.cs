using Softtek.Academy.Final.Data.Configurations;
using Softtek.Academy.Final.Domain.Model;
using System.Data.Entity;

namespace Softtek.Academy.Final.Data
{
    public class SurveySystemDbContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public SurveySystemDbContext() : base("SurveySystemDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SurveySystemDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new SurveyConfiguration());
            modelBuilder.Configurations.Add(new OptionConfiguration());
            modelBuilder.Configurations.Add(new QuestionTypeConfiguration());
        }
    }
}
