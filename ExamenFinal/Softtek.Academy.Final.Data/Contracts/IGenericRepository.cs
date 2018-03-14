using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        T Get(int id);

        ICollection<T> GetAll();
    }
}
