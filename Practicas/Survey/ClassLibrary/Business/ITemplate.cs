using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Business
{
    public interface IGenericRepository<T> where T : class
    {
        void CreateQuestion(T question);
        List<T> ReadQuestion(string filter);
        List<T> UpdateQuestion(int id, T question);
        void DeleteQuestion(int id);
    }
}
