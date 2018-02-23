using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class ItemDataRepository : IItemRepository
    {
        public bool AssignDueDate(DateTime dueDate, int id)
        {
            using (var ctx = new ToDoListContext())
            {
                if (dueDate == null) return false;

                Item item = ctx.Items.SingleOrDefault(i => i.Id == id);

                if (item == null) return false;

                item.DueDate = dueDate;
                ctx.SaveChanges();

                return true;
            }
        }

        public bool AssignPriority(int itemid, int priorityid)
        {
            using (var ctx = new ToDoListContext())
            {
                if (itemid <= 0 || priorityid <= 0) return false;

                Item currentitem = ctx.Items.SingleOrDefault(i => i.Id == itemid);

                if (currentitem == null) return false;

                currentitem.PriorityId = priorityid;
                currentitem.ModifiedDate = DateTime.Now;
                ctx.SaveChanges();

                return true;
            }
        }

        public bool AssignStatus(int itemid, int statusid)
        {
            using (var ctx = new ToDoListContext())
            {
                if (itemid <= 0 || statusid <= 0) return false;

                Item currentitem = ctx.Items.SingleOrDefault(i => i.Id == itemid);
                Status currentstatus = ctx.Status.SingleOrDefault(s => s.Id == statusid);

                if (currentitem == null || currentstatus == null) return false;

                currentitem.Status = currentstatus;
                currentitem.StatusId = currentstatus.Id;
                currentitem.ModifiedDate = DateTime.Now;
                ctx.SaveChanges();

                return true;
            }
        }

        public bool AssignTask(int itemid, int tagid)
        {
            using (var ctx = new ToDoListContext())
            {
                if (itemid <= 0 || tagid <= 0) return false;

                Item currentitem = ctx.Items.SingleOrDefault(i => i.Id == itemid);
                Tag currenttag = ctx.Tag.SingleOrDefault(s => s.Id == tagid);

                if (currentitem == null || currenttag == null) return false;

                currentitem.Tags.Add(currenttag);
                currenttag.Items.Add(currentitem);
                currentitem.ModifiedDate = DateTime.Now;
                currenttag.ModifiedDate = DateTime.Now;
                ctx.SaveChanges();

                return true;
            }
        }

        public int CountTags(int itemid)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Items.SingleOrDefault(t => t.Id == itemid).Tags.Count();
            }
        }

        public int Create(Item item)
        {
            using (var ctx = new ToDoListContext())
            {
                if (item == null) return 0;

                item.CreatedDate = DateTime.Now;
                item.IsArchived = false;
                item.StatusId = 1;
                item.PriorityId = 1;
                item.DueDate = null;
                item.ModifiedDate = null;

                ctx.Items.Add(item);
                ctx.SaveChanges();

                return item.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                if (id <= 0) return false;

                Item currentitem = ctx.Items.SingleOrDefault(t => t.Id == id);

                if (currentitem == null || currentitem.IsArchived == true) return false;

                currentitem.IsArchived = true;
                ctx.SaveChanges();

                return true;
            }
        }

        public Item Get(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Items.SingleOrDefault(t => t.Id == id && t.IsArchived == false);
            }
        }

        public List<Item> GetByPriority()
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Items.OrderByDescending(i => i.PriorityId).ToList();
            }
        }

        public List<Item> GetByStatus()
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Items.OrderByDescending(i => i.StatusId).ToList();
            }
        }

        public List<Item> GetByTitle()
        {
            using (var ctx = new ToDoListContext())
            {
                List<Item> query = ctx.Items
                .Where(s => s.IsArchived == false)
                .OrderBy(s => s.Title).ToList();
                return query;
            }
        }

        public bool Update(Item item)
        {
            using (var ctx = new ToDoListContext())
            {
                if (item == null) return false;

                Item currentitem = ctx.Items.SingleOrDefault(t => t.Id == item.Id);

                if (currentitem == null) return false;

                currentitem.Title = item.Title;
                currentitem.Description = item.Description;
                currentitem.ModifiedDate = DateTime.Now;

                return true;
            }
        }
    }
}
