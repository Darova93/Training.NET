using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Entities;
using ClassLibrary.Interface;

namespace ClassLibrary.Interface
{
    public class TagRepository : IGenericRepository<Tag>
    {
        public readonly List<Tag> TagList;
        public readonly List<ItemTags> ItemTagList;

        public TagRepository (List<Tag> tagList)
        {
            this.TagList = tagList;
        }

        public void Create(Tag item)
        {
            if (SearchName(item.Name) == false)
            {
                TagList.Add(item);
            }
        }

        public void Delete(int id)
        {
            if (ItemTagList.Where(e => e.TagId == id).FirstOrDefault().Equals(String.Empty))
            {
                TagList.Remove(SearchId(id));
            }
            else
            {
                Console.WriteLine("The tag is assigned to a task");
            }

        }

        public List<Tag> Read(string filter)
        {
            return TagList.Where(e => e.Name == filter).ToList();
        }

        public Tag SearchId(int id)
        {
            return TagList.Where(e => e.Id == id).FirstOrDefault();
        }

        public bool SearchName(string name)
        {
            if (TagList.Where(e => e.Name == name).ToList().Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AssignTag(ItemTags item)
        {
            List<ItemTags> repetitions = new List<ItemTags>();
            repetitions = ItemTagList.Where(e => e.ItemId == item.ItemId).ToList();
            if (repetitions.Count<10)
            {
                ItemTagList.Add(item);
            }
            else
            {
                Console.WriteLine("Too many tags assigned to that task");
            }
            return repetitions.Count;
        }
    }
}
