using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreriadeclases.Entidades;

namespace Libreriadeclases.Negocios
{
    public class EmployeeRepository : IGenericRepository<Empleados>
    {
        public EmployeeRepository()
        {

        }

        private readonly List<Empleados> Listaempleados;

        public EmployeeRepository(List<Empleados> listaempleados)
        {
            Listaempleados = listaempleados;
        }

        public List<Empleados> Actualizar(Empleados objeto)
        {
            Listaempleados[Listaempleados.FindIndex(index => index.Id == objeto.Id)] = objeto;
            return Listaempleados;
        }

        public void Agregar(Empleados objeto)
        {
            Listaempleados.Add(objeto);
        }

        public bool Borrar(int id)
        {
            return Listaempleados.Remove(BuscarId(id));
        }

        public List<Empleados> Buscar(string filtro = "")
        {
            if (filtro.Equals(string.Empty))
            {
                return Listaempleados;
            }
            else
            {
                return Listaempleados.Where(e => e.Nombrecompleto.Contains(filtro)).ToList();
            }
        }

        public Empleados BuscarId(int id)
        {
            return Listaempleados.Where(e => e.Id == id).FirstOrDefault();
        }

        public Empleados Buscarpornombre(string nombre)
        {
            return Listaempleados.Where(e => e.Nombre == nombre).FirstOrDefault();
        }

        public Empleados Buscarporapellidom(string apellidop)
        {
            return Listaempleados.Where(e => e.Apellidop == apellidop).FirstOrDefault();
        }

        public Empleados Buscarporapellidop(string apellidom)
        {
            return Listaempleados.Where(e => e.Apellidom == apellidom).FirstOrDefault();
        }
    }
}
