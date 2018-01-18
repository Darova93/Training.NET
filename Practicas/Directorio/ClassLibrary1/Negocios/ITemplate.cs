using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreriadeclases.Negocios
{
    public interface IGenericRepository<T> where T : class
    {
        void Agregar(T objeto);
        T Actualizar(T objeto);
        bool Borrar(int id);
        T BuscarId(int id);
        List<T> Buscar(string filtro);
    }
}
