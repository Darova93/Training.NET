using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        int CountItems(int id);
        int TagExists(string Name);
        List<Tag> GetAll();
    }
}
