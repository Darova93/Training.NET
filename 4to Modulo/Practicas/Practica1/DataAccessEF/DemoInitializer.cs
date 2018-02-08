using DataAccessEF.Entities;
using System.Data.Entity;

namespace DataAccessEF
{
    class DemoInitializer : DropCreateDatabaseAlways<DemoContext>
    {
        protected override void Seed(DemoContext context)
        {
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 1, Description = "Si/No" });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 2, Description = "Abierta" });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 3, Description = "Opcion Multiple" });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 4, Description = "Test Question" });

            context.Questions.Add(new Question { QuestionId = 1, QuestionTypeId = 1, IsActive = false, IsRequired = false, Text = "¿Hace frio en invierno en el polo sur?" });
            context.Questions.Add(new Question { QuestionId = 2, QuestionTypeId = 1, IsActive = false, IsRequired = false, Text = "¿La tierra gira alrededor del sol?" });
            context.Questions.Add(new Question { QuestionId = 3, QuestionTypeId = 3, IsActive = false, IsRequired = false, Text = "¿A donde vuelan los pinguinos en invierno?" });
            context.Questions.Add(new Question { QuestionId = 4, QuestionTypeId = 2, IsActive = false, IsRequired = false, Text = "Explica el estoicismo" });

            context.Options.Add(new Option { OptionId = 1, Text = "Africa" });
            context.Options.Add(new Option { OptionId = 2, Text = "Toronto" });
            context.Options.Add(new Option { OptionId = 3, Text = "Cancun" });
            context.Options.Add(new Option { OptionId = 4, Text = "Los pingus no vuelan" });
            context.Options.Add(new Option { OptionId = 5, Text = "Concepción ética de esta escuela según la cual el bien no está en los objetos externos, sino en la sabiduría y dominio del alma, que permite liberarse de las pasiones y deseos que perturban la vida." });
            context.Options.Add(new Option { OptionId = 6, Text = "Si" });
            context.Options.Add(new Option { OptionId = 7, Text = "No" });

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
