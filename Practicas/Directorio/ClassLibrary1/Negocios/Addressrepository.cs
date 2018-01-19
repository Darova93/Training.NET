using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreriadeclases.Entidades;

namespace Libreriadeclases.Negocios
{
    class AddressRepository : IGenericRepository<Direcciones>
    {
        public AddressRepository()
        {

        }

        private readonly List<Direcciones> Listadirecciones;

        public AddressRepository(List<Direcciones> listadirecciones)
        {
            Listadirecciones = listadirecciones;
        }

        public List<Direcciones> Actualizar(Direcciones objeto)
        {
            Listadirecciones[Listadirecciones.FindIndex(index => index.Id == objeto.Id)] = objeto;
            return Listadirecciones;
        }

        public void Agregar(Direcciones objeto)
        {
            Listadirecciones.Add(objeto);
        }

        public bool Borrar(int id)
        {
            return Listadirecciones.Remove(BuscarId(id));
        }

        public List<Direcciones> Buscar(string filtro = "")
        {
            if (filtro.Equals(string.Empty))
            {
                return Listadirecciones;
            }
            else
            {
                return Listadirecciones.Where(e => e.Direccioncompleta.Contains(filtro)).ToList();
            }
        }

        public Direcciones BuscarId(int id)
        {
            return Listadirecciones.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
