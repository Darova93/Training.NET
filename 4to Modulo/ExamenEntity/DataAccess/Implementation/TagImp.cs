using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO;
using DataAccess.Entities;
using DataAccess.Helpers;

namespace DataAccess.Implementation
{
    public class TagImp : ITagRepository
    {
        public void AddTag(TagDTO tagDTO)
        {
            TagEF tagEF = DataConverter.ConvertTagDTOtoEntity(tagDTO);
            using (var context = new DemoContext())
            {
                if (ValidateUnique(tagEF.Description)==true)
                {
                    context.Tags.Add(tagEF);
                    context.SaveChanges(); 
                }
            }
        }

        public void AssignTagtoTask(int taskid, int tagid)
        {
            using(var context = new DemoContext())
            {
                TagEF tagtoadd = context.Tags.Find(tagid);
                TaskEF task = context.Tasks.Find(taskid);

                if ((tagtoadd!=null) && (CountTags(taskid) < 10) && (tagtoadd.IsArchived==false))
                {
                    task.Tags.Add(tagtoadd);
                    tagtoadd.Tasks.Add(task);
                    context.SaveChanges();
                }
            }
        }
       
        public void DeleteTag(int tagid)
        {
            using (var context = new DemoContext())
            {
                var tag = context.Tags.Find(tagid);
                if ((tag != null) && (CountTask(tagid)==0))
                {
                    tag.IsArchived = true;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("ERROR: The the tag is assigned to a task");
                }
            }
        }

        public int CountTask(int tagid)
        {
            using (var context = new DemoContext())
            {
                var tag = context.Tags.Find(tagid);
                if (tag != null)
                {
                    return tag.Tasks.Count(q=>q.IsArchived==false);
                }
                else
                {
                    Console.WriteLine("ERROR: Tag does not exist");
                    return 0;
                }
            }
        }

        private int CountTags(int taskid)
        {
            using (var context = new DemoContext())
            {
                var task = context.Tasks.Find(taskid);
                if (task != null)
                {
                    return task.Tags.Count(q => q.IsArchived == false);
                }
                else
                {
                    return 10;
                }
            }
        }

        private bool ValidateUnique(string description)
        {
            using (var context = new DemoContext())
            {
                var tag = context.Tags.FirstOrDefault(t => t.Description == description);
                if ((tag != null) && (tag.Description == description))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
