using System.Collections.Generic;

namespace Softtek.Academy.Final.Data.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        T Get(int id);

        ICollection<T> GetAll();
    }
}
