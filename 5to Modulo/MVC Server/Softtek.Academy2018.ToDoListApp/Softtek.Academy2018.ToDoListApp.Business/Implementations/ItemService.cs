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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IStatusRepository _statrepository;
        private readonly ITagRepository _tagrepository;

        public ItemService(IItemRepository repository, IStatusRepository statrepository, ITagRepository tagrepository)
        {
            _repository = repository;
            _statrepository = statrepository;
            _tagrepository = tagrepository;
        }

        public bool AssignDueDate(DateTime dueDate, int id)
        {
            if (dueDate == null) return false;
            if (id <= 0) return false;

            if (dueDate <= DateTime.Now.AddSeconds(30)) return false;
            Item itemExists = _repository.Get(id);
            if (itemExists == null) return false;

            bool result = _repository.AssignDueDate(dueDate, id);
            return result;
        }

        public bool AssignPriority(int itemid, int priorityid)
        {
            if (itemid <= 0 || priorityid <= 0) return false;

            Item itemExists = _repository.Get(itemid);
            if (itemExists == null) return false;

            var result = _repository.AssignPriority(itemid, priorityid);
            return result;
        }

        public bool AssignStatus(int itemid, int statusid)
        {
            if (itemid <= 0 || statusid <= 0) return false;

            Item itemExists = _repository.Get(itemid);
            Status statusExists = _statrepository.Get(statusid);
            if (itemExists == null || statusExists == null) return false;

            var result = _repository.AssignStatus(itemid, statusid);
            return result;
        }

        public bool AssignTask(int itemid, int tagid)
        {
            if (itemid <= 0 || tagid <= 0) return false;

            Item itemExists = _repository.Get(itemid);
            Tag tagExists = _tagrepository.Get(tagid);
            if (itemExists == null || tagExists == null) return false;

            int tags = _repository.CountTags(itemid);
            if (tags >= 10) return false;

            var result = _repository.AssignTask(itemid, tagid);
            return result;
        }

        public int Create(Item item)
        {
            if (item == null) return 0;

            if (string.IsNullOrEmpty(item.Description) || string.IsNullOrEmpty(item.Title)) return 0;

            if (item.Title.Count() > 250) return 0;
            if (item.Description.Count() > 500) return 0;

            int id = _repository.Create(item);

            return id;
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            Item itemExists = _repository.Get(id);
            if (itemExists == null) return false;

            if (itemExists.IsArchived == true) return false;

            bool result = _repository.Delete(id);

            return result;
        }

        public Item Get(int id)
        {
            if (id <= 0) return null;

            var item = _repository.Get(id);

            return item;
        }

        public List<Item> GetByPriority()
        {
            return _repository.GetByPriority().Where(i => i.IsArchived == false).ToList();
        }

        public List<Item> GetByStatus()
        {
            return _repository.GetByStatus().Where(i => i.IsArchived == false).ToList();
        }

        public List<Item> GetByTitle()
        {
            return _repository.GetByTitle().Where(i => i.IsArchived == false).ToList();
        }

        public bool Update(Item item)
        {
            if (item == null) return false;

            if (string.IsNullOrEmpty(item.Description) || string.IsNullOrEmpty(item.Title)) return false;

            if (item.PriorityId <= 0) return false;

            bool result = _repository.Update(item);

            return result;
        }
    }
}
