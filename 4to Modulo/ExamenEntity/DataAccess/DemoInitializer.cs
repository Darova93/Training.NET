using DataAccess.Entities;
using DataAccess.Implementation;
using Interfaces.Interfaces;
using System.Data.Entity;

namespace DataAccess
{
    class DemoInitializer : DropCreateDatabaseAlways<DemoContext>
    {
        protected override void Seed(DemoContext context)
        {
            ITagRepository tagRepository = new TagImp();

            context.Tasks.Add(new TaskEF { Title = "Primer Task", Description = "Descripcion primer task" });
            context.Tasks.Add(new TaskEF { Title = "Segundo Task", Description = "Descripcion segundo task" });
            context.Tasks.Add(new TaskEF { Title = "Tercer Task", Description = "Descripcion tercer task" });
            context.Tasks.Add(new TaskEF { Title = "Cuarto Task", Description = "Descripcion cuarto task" });
            context.Tasks.Add(new TaskEF { Title = "Quinto Task", Description = "Descripcion quinto task" });
            context.Tasks.Add(new TaskEF { Title = "Sexto Task", Description = "Descripcion sexto task" });
            context.Tasks.Add(new TaskEF { Title = "Septimo Task", Description = "Descripcion septimo task" });
            context.Tasks.Add(new TaskEF { Title = "Octavo Task", Description = "Descripcion octavo task" });
            context.Tasks.Add(new TaskEF { Title = "Noveno Task", Description = "Descripcion octavo task" });

            context.Tags.Add(new TagEF { Description = "Primer Tag" });
            context.Tags.Add(new TagEF { Description = "Primer Tag" });
            context.Tags.Add(new TagEF { Description = "Segundo Tag" });
            context.Tags.Add(new TagEF { Description = "Tercer Tag" });
            context.Tags.Add(new TagEF { Description = "Cuarto Tag" });
            context.Tags.Add(new TagEF { Description = "Quinto Tag" });
            context.Tags.Add(new TagEF { Description = "Sexto Tag" });
            context.Tags.Add(new TagEF { Description = "Septimo Tag" });
            context.Tags.Add(new TagEF { Description = "Octavo Tag" });
            context.Tags.Add(new TagEF { Description = "Noveno Tag" });
            context.Tags.Add(new TagEF { Description = "Decimo Tag" });
            context.Tags.Add(new TagEF { Description = "Onceavo Tag" });
            context.Tags.Add(new TagEF { Description = "Doceavo Tag" });
            context.Tags.Add(new TagEF { Description = "Treceavo Tag" });
            context.Tags.Add(new TagEF { Description = "Catorceavo Tag" });

            tagRepository.AssignTagtoTask(1, 1);
            tagRepository.AssignTagtoTask(2, 1);
            tagRepository.AssignTagtoTask(3, 1);
            tagRepository.AssignTagtoTask(1, 2);
            tagRepository.AssignTagtoTask(1, 3);
            tagRepository.AssignTagtoTask(1, 4);
            tagRepository.AssignTagtoTask(1, 5);
            tagRepository.AssignTagtoTask(1, 6);
            tagRepository.AssignTagtoTask(1, 7);
            tagRepository.AssignTagtoTask(1, 8);
            tagRepository.AssignTagtoTask(1, 9);
            tagRepository.AssignTagtoTask(1, 10);
            tagRepository.AssignTagtoTask(1, 11);
            tagRepository.AssignTagtoTask(1, 12);
            tagRepository.AssignTagtoTask(1, 13);
            tagRepository.AssignTagtoTask(2, 3);
            tagRepository.AssignTagtoTask(3, 5);
            tagRepository.AssignTagtoTask(4, 11);
            tagRepository.AssignTagtoTask(5, 9);
            tagRepository.AssignTagtoTask(6, 3);
            tagRepository.AssignTagtoTask(7, 6);
            tagRepository.AssignTagtoTask(7, 7);
            tagRepository.AssignTagtoTask(8, 10);
            tagRepository.AssignTagtoTask(9, 12);
            tagRepository.AssignTagtoTask(9, 14);

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
