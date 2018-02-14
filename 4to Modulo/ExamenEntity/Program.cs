using DataAccess.Implementation;
using DTO.DTO;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaskRepository taskRepository = new TaskImp();
            ITagRepository tagRepository = new TagImp();

            //taskRepository.AddTask(new TaskDTO { Title = "Primer Task", Description = "Descripcion primer task"});
            //taskRepository.AddTask(new TaskDTO { Title = "Segundo Task", Description = "Descripcion segundo task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Tercer Task", Description = "Descripcion tercer task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Cuarto Task", Description = "Descripcion cuarto task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Quinto Task", Description = "Descripcion quinto task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Sexto Task", Description = "Descripcion sexto task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Septimo Task", Description = "Descripcion septimo task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Octavo Task", Description = "Descripcion octavo task" });
            //taskRepository.AddTask(new TaskDTO { Title = "Noveno Task", Description = "Descripcion octavo task" });

            //DateTime newdate = new DateTime(2019, 6, 1);
            //DateTime olddate = new DateTime(2017, 6, 1);
            //taskRepository.AssignDueDate(2, newdate);
            //taskRepository.AssignDueDate(3, olddate);

            //taskRepository.AssignStatus(1, Status.Cancel);
            //taskRepository.AssignStatus(3, Status.InProgress);

            //taskRepository.AssignPriority(1, 5);
            //taskRepository.AssignPriority(2, 3);
            //taskRepository.AssignPriority(3, 0);
            //taskRepository.AssignPriority(4, 2);
            //taskRepository.AssignPriority(5, 6);
            //taskRepository.AssignPriority(6, 3);

            //taskRepository.DeleteTask(3);
            //taskRepository.UpdateTask(new TaskDTO { TaskId = 1, Title = "Primer Task", Description = "Descripcion Actualizada" });

            //tagRepository.AddTag(new TagDTO { Description = "Primer Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Primer Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Segundo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Tercer Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Cuarto Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Quinto Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Sexto Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Septimo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Octavo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Noveno Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Decimo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Onceavo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Doceavo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Treceavo Tag" });
            //tagRepository.AddTag(new TagDTO { Description = "Catorceavo Tag" });

            //tagRepository.AssignTagtoTask(1, 1);
            //tagRepository.AssignTagtoTask(2, 1);
            //tagRepository.AssignTagtoTask(3, 1);
            //tagRepository.AssignTagtoTask(1, 2);
            //tagRepository.AssignTagtoTask(1, 3);
            //tagRepository.AssignTagtoTask(1, 4);
            //tagRepository.AssignTagtoTask(1, 5);
            //tagRepository.AssignTagtoTask(1, 6);
            //tagRepository.AssignTagtoTask(1, 7);
            //tagRepository.AssignTagtoTask(1, 8);
            //tagRepository.AssignTagtoTask(1, 9);
            //tagRepository.AssignTagtoTask(1, 10);
            //tagRepository.AssignTagtoTask(1, 11);
            //tagRepository.AssignTagtoTask(1, 12);
            //tagRepository.AssignTagtoTask(1, 13);
            //tagRepository.AssignTagtoTask(2, 3);
            //tagRepository.AssignTagtoTask(3, 5);
            //tagRepository.AssignTagtoTask(4, 11);
            //tagRepository.AssignTagtoTask(5, 9);
            //tagRepository.AssignTagtoTask(6, 3);
            //tagRepository.AssignTagtoTask(7, 6);
            //tagRepository.AssignTagtoTask(7, 7);
            //tagRepository.AssignTagtoTask(8, 10);
            //tagRepository.AssignTagtoTask(9, 12);
            //tagRepository.AssignTagtoTask(9, 14);

            //tagRepository.DeleteTag(13);
            //tagRepository.DeleteTag(15);

            //var num1 = tagRepository.CountTask(1);
            //var num2 = tagRepository.CountTask(2);
            //var num3 = tagRepository.CountTask(20);
            //var num4 = tagRepository.CountTask(13);
            //Console.WriteLine("{0}, {1}, {2}, {3}", num1, num2, num3, num4);

            taskRepository.GetAll();
            taskRepository.GetTaskByPriority();
            taskRepository.GetTaskByStatus();
            taskRepository.GetTaskByTitle();
        }
    }
}
