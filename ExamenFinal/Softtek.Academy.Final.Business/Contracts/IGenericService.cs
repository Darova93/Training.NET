using System.Collections.Generic;

namespace Softtek.Academy.Final.Business.Contracts
{
    public interface IGenericService<T> where T : class
    {
        T Get(int id);

        ICollection<T> GetAll();
    }
}
