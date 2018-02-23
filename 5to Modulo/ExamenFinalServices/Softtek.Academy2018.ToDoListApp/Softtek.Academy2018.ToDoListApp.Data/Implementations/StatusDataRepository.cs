using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class StatusDataRepository : IStatusRepository
    {
        public Status Get(int id)
        {
            using (var ctx = new ToDoListContext())
            {
                return ctx.Status.SingleOrDefault(s => s.Id == id);
            }
        }
    }
}
