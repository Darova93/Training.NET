namespace Softtek.Academy.Final.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Softtek.Academy.Final.Data.SurveySystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Softtek.Academy.Final.Data.SurveySystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.QuestionTypes.Add(new Domain.Model.QuestionType { Id = 1, Description = "Open", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.QuestionTypes.Add(new Domain.Model.QuestionType { Id = 2, Description = "Single", CreatedDate = DateTime.Now, ModifiedDate = null });
            context.QuestionTypes.Add(new Domain.Model.QuestionType { Id = 3, Description = "Multiple", CreatedDate = DateTime.Now, ModifiedDate = null });

            //context.Questions.Add(new Domain.Model.Question { Id = 2, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Questions.Add(new Domain.Model.Question { Id = 1, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Questions.Add(new Domain.Model.Question { Id = 3, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });

            //context.Options.Add(new Domain.Model.Option { Id = 1, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Options.Add(new Domain.Model.Option { Id = 2, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Options.Add(new Domain.Model.Option { Id = 3, Text = "", CreatedDate = DateTime.Now, ModifiedDate = null });
        }
    }
}
