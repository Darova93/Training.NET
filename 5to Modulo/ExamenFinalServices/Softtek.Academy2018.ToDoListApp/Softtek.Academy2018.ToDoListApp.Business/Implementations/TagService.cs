using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;

namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagrepository;

        public TagService(ITagRepository tagrepository)
        {
            _tagrepository = tagrepository;
        }

        public int CountItems(int id)
        {
            if (id <= 0) return 0;

            Tag tagExists = _tagrepository.Get(id);
            if (tagExists == null) return 0;

            int items = _tagrepository.CountItems(id);
            return items;
        }

        public int Create(Tag item)
        {
            if (item == null) return 0;

            if (string.IsNullOrEmpty(item.Name)) return 0;

            if (item.Name.Count() > 250) return 0;

            int tagExists = _tagrepository.TagExists(item.Name);
            if (tagExists!=0) return 0;

            int id = _tagrepository.Create(item);

            return id;
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            Tag tagExists = _tagrepository.Get(id);
            if (tagExists == null) return false;

            if (tagExists.IsActive == false) return false;

            int itemsAssigned = _tagrepository.CountItems(id);
            if (itemsAssigned > 0)
            {
                //Console.WriteLine("The Tag is associated with a Task, do you want to proceed? [y/n]");
                //string ans = Console.ReadLine();
                //if(ans == "n")
                //{
                //    return false;
                //}
                return false;
            }

            bool result = _tagrepository.Delete(id);

            return result;
        }

        public Tag Get(int id)
        {
            if(id <= 0) return null;

            var item = _tagrepository.Get(id);

            return item;
        }

        public bool Update(Tag item)
        {
            if (item == null) return false;

            if (string.IsNullOrEmpty(item.Name)) return false;

            int tagExists = _tagrepository.TagExists(item.Name);

            if (tagExists!=item.Id) return false;

            var result = _tagrepository.Update(item);

            return result;
        }
    }
}
