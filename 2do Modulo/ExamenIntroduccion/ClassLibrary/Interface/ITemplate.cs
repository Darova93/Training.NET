using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    interface IGenericRepository <T> where T : class
    {
        void Create(T item);
        List<T> Read(string filter);
        void Delete(int id);

    }
}
