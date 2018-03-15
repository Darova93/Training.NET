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

            context.Questions.Add(new Domain.Model.Question { Id = 1, Text = "How do you qualify the content of the Foundations module?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 2, Text = "How do you qualify the content of the Database module?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 3, Text = "How do you qualify the content of the Data Access module?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 4, Text = "How do you qualify the content of the Business module?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 5, Text = "What is your name?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 6, Text = "Where did you study?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 7, Text = "How old are you?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 8, Text = "What is your favorite book?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 9, Text = "Where are you from?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 10, Text = "Where do you live?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 11, Text = "How much money do you earn?", QuestionTypeId = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 12, Text = "Select your favorite styles of music", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 13, Text = "Which social medias do you use?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 14, Text = "Which pets do you own right now?", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 15, Text = "Select your favorite beverages", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 16, Text = "Select the operating systems you use", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Questions.Add(new Domain.Model.Question { Id = 17, Text = "Select the internet browser you use", QuestionTypeId = 2, CreatedDate = DateTime.Now, ModifiedDate = null });

            context.Options.Add(new Domain.Model.Option { Id = 1, Text = "Easy", QuestionId = 1, Value = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 2, Text = "Medium", QuestionId = 1, Value = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 3, Text = "Normal", QuestionId = 1, Value = 3, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 4, Text = "Advanced", QuestionId = 1, Value = 4, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 5, Text = "Expert", QuestionId = 1, Value = 5, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 6, Text = "Easy", QuestionId = 2, Value = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 7, Text = "Medium", QuestionId = 2, Value = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 8, Text = "Normal", QuestionId = 2, Value = 3, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 9, Text = "Advanced", QuestionId = 2, Value = 4, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 10, Text = "Expert", QuestionId = 2, Value = 5, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 11, Text = "Easy", QuestionId = 3, Value = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 12, Text = "Medium", QuestionId = 3, Value = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 13, Text = "Normal", QuestionId = 3, Value = 3, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 14, Text = "Advanced", QuestionId = 3, Value = 4, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 15, Text = "Expert", QuestionId = 3, Value = 5, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 16, Text = "Easy", QuestionId = 4, Value = 1, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 17, Text = "Medium", QuestionId = 4, Value = 2, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 18, Text = "Normal", QuestionId = 4, Value = 3, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 19, Text = "Advanced", QuestionId = 4, Value = 4, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 20, Text = "Expert", QuestionId = 4, Value = 5, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 21, Text = "Rock", QuestionId = 12, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 22, Text = "Pop", QuestionId = 12, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 23, Text = "Country", QuestionId = 12, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 24, Text = "Metal", QuestionId = 12, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 25, Text = "Electronic", QuestionId = 12, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 26, Text = "Facebook", QuestionId = 13, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 27, Text = "Instagram", QuestionId = 13, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 28, Text = "Twitter", QuestionId = 13, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 29, Text = "Google+", QuestionId = 13, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 30, Text = "Dog", QuestionId = 14, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 31, Text = "Cat", QuestionId = 14, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 32, Text = "Fish", QuestionId = 14, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 33, Text = "Hamster", QuestionId = 14, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 34, Text = "Other", QuestionId = 14, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 35, Text = "Beer", QuestionId = 15, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 36, Text = "Water", QuestionId = 15, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 37, Text = "Juice", QuestionId = 15, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 38, Text = "Milk", QuestionId = 15, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 39, Text = "Windows", QuestionId = 16, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 40, Text = "Ubuntu", QuestionId = 16, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 41, Text = "Mac OS", QuestionId = 16, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 42, Text = "Internet Explorer", QuestionId = 17, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 43, Text = "Mozilla Firefox", QuestionId = 17, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 44, Text = "Google Chrome", QuestionId = 17, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
            context.Options.Add(new Domain.Model.Option { Id = 45, Text = "Other", QuestionId = 17, Value = null, CreatedDate = DateTime.Now, ModifiedDate = null });
        }
    }
}
