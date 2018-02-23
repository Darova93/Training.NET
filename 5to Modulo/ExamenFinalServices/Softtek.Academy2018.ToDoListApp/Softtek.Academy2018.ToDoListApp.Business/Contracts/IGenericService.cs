using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Contracts
{
    public interface IGenericService<T> where T:class
    {
        int Create(T item);
        bool Delete(int id);
        bool Update(T item);
        T Get(int id);
    }
}
