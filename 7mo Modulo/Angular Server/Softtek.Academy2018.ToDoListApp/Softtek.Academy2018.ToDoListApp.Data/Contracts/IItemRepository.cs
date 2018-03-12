using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        List<Item> GetByTitle();
        List<Item> GetByStatus();
        List<Item> GetByPriority();
        bool AssignDueDate(DateTime dueDate, int id);
        bool AssignPriority(int itemid, int priorityid);
        bool AssignTask(int itemid, int tagid);
        bool AssignStatus(int itemid, int statusid);
        int CountTags(int itemid);
    }
}
