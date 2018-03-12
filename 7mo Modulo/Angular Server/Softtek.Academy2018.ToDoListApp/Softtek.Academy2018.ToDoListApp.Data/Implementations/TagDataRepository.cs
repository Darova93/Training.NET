using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class TagDataRepository : ITagRepository
    {
        public int CountItems(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                Tag currenttag = ctx.Tag.SingleOrDefault(t => t.Id == id);

                int items = currenttag.Items.Count();

                return items;
            }
        }

        public int Create(Tag item)
        {
            using (var ctx = new ToDoListContext())
            {
                if (item == null) return 0;

                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = null;
                item.IsActive = true;
                
                ctx.Tag.Add(item);
                ctx.SaveChanges();

                return item.Id;
            }
        }

        public bool Delete(int id)
        {
            using(var ctx = new ToDoListContext())
            {
                if (id <= 0) return false;

                Tag currenttag = ctx.Tag.SingleOrDefault(t => t.Id == id);

                if (currenttag == null || currenttag.IsActive == false) return false;

                currenttag.IsActive = false;
                ctx.SaveChanges();

                return true;
            }
        }

        public Tag Get(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Tag.SingleOrDefault(t => t.Id == id);
            }
        }

        public List<Tag> GetAll()
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Tag.OrderByDescending(t => t.Id).ToList();
            }
        }

        public int TagExists(string Name)
        {
            using (var ctx = new ToDoListContext())
            {
                if(!ctx.Tag.Any(t => t.Name.ToLower() == Name.ToLower())) return 0;
                Tag tag = ctx.Tag.FirstOrDefault(t => t.Name.ToLower() == Name.ToLower());
                return tag.Id;
            }
        }

        public bool Update(Tag item)
        {
            using (var ctx = new ToDoListContext())
            {
                if (item == null) return false;

                Tag currenttag = ctx.Tag.SingleOrDefault(t => t.Id == item.Id);

                if (currenttag == null) return false;

                currenttag.Name = item.Name;
                currenttag.ModifiedDate = DateTime.Now;

                return true;
            }
        }
    }
}
