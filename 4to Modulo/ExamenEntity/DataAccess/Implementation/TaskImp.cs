using DataAccess.Entities;
using DataAccess.Helpers;
using DTO.DTO;
using System.Linq;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccess.Implementation
{
    public class TaskImp : ITaskRepository
    {
        public void AddTask(TaskDTO taskDTO)
        {
            TaskEF EFTask = DataConverter.ConvertTaskDTOtoEntity(taskDTO);
            using (var context = new DemoContext())
            {
                if (ValidateDate(EFTask.DueDate) == true)
                {
                    context.Tasks.Add(EFTask);
                    context.SaveChanges(); 
                }
            }
        }

        public void AssignStatus(int taskid, Status stat)
        {
            using (var context = new DemoContext())
            {
                var task = context.Tasks.Find(taskid);
                if (task != null)
                {
                    switch (task.Status)
                    {
                        case Status.Draft: 
                            if (stat == Status.New)
                            {
                                task.Status = stat;
                            }
                            else
                            {
                                Console.WriteLine("Can't assign that status");
                            }
                            break;
                        case Status.New:
                            if((stat == Status.Draft) || (stat == Status.Cancel) || (stat == Status.InProgress))
                            {
                                task.Status = stat;
                            }
                            else
                            {
                                Console.WriteLine("Can't assign that status");
                            }
                            break;
                        case Status.InProgress:
                            if ((stat == Status.Draft) || (stat == Status.Cancel) || (stat == Status.Done))
                            {
                                task.Status = stat;
                            }
                            else
                            {
                                Console.WriteLine("Can't assign that status");
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Status");
                            break;
                    }
                    context.SaveChanges();
                }
            }
        }

        public void AssignDueDate(int taskid, DateTime duedate)
        {
            using(var context = new DemoContext())
            {
                var task = context.Tasks.FirstOrDefault(t => t.TaskId == taskid);
                if ((task != null) && (ValidateDate(duedate)==true))
                {
                    task.DueDate = duedate;
                    context.SaveChanges();
                }
            }
        }

        public void AssignPriority(int taskid, int priority)
        {
            using (var context = new DemoContext())
            {
                var task = context.Tasks.Find(taskid);
                if ((task != null) && (priority >= 1))
                {
                    task.Priority = priority;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTask(int taskid)
        {
            using (var context = new DemoContext())
            {
                var task = context.Tasks.Find(taskid);
                if (task != null)
                {
                    task.IsArchived = true;
                    context.SaveChanges();
                }
            }
        }

        private bool ValidateDate(DateTime time)
        {
            DateTime today = DateTime.Now;
            if (time >= today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //*************************************************************************************GET

        public List<TaskDTO> GetAll()
        {
            List<TaskDTO> list = new List<TaskDTO>();
            using(var context = new DemoContext())
            {
                foreach(TaskEF task in context.Tasks)
                {
                    list.Add(DataConverter.ConvertTaskEntitytoDTO(task));
                }
                list.Select(p => p.IsArchived == false);
            }
            return list;
        }

        public List<TaskDTO> GetTaskByStatus()
        {
            List<TaskDTO> list = new List<TaskDTO>();
            using (var context = new DemoContext())
            {
                context.Tasks.OrderByDescending(p => p.Status).Where(p => p.IsArchived == false);
                foreach (TaskEF task in context.Tasks)
                {
                    list.Add(DataConverter.ConvertTaskEntitytoDTO(task));
                }
            }
            return list;
        }

        public List<TaskDTO> GetTaskByTitle()
        {
            List<TaskDTO> list = new List<TaskDTO>();
            using (var context = new DemoContext())
            {
                context.Tasks.OrderByDescending(p => p.Title).Where(p => p.IsArchived == false);
                foreach (TaskEF task in context.Tasks)
                {
                    list.Add(DataConverter.ConvertTaskEntitytoDTO(task));
                }
            }
            return list;
        }

        public List<TaskDTO> GetTaskByPriority()
        {
            List<TaskDTO> list = new List<TaskDTO>();
            using (var context = new DemoContext())
            {
                context.Tasks.OrderByDescending(p => p.Priority).Where(p => p.IsArchived == false);
                foreach (TaskEF task in context.Tasks)
                {
                    list.Add(DataConverter.ConvertTaskEntitytoDTO(task));
                }
            }
            return list;
        }

        public void UpdateTask(TaskDTO taskDTO)
        {
            using (var context = new DemoContext())
            {
                var oldtask = context.Tasks.FirstOrDefault(t => t.TaskId == taskDTO.TaskId);
                oldtask.Title = taskDTO.Title;
                oldtask.Description = taskDTO.Description;
                context.SaveChanges();
            }
        }
    }
}
