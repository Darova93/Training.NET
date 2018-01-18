using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreriadeclases.Entidades;

namespace Libreriadeclases.Negocios
{
    class EmployeeRepository : IGenericRepository<Empleados>
    {
        public EmployeeRepository()
        {

        }

        private readonly List<Empleados> Listaempleados;

        public EmployeeRepository(List<Empleados> listaempleados)
        {
            Listaempleados = listaempleados;
        }

        public Empleados Actualizar(Empleados objeto)
        {
            return objeto;
        }

        public Empleados Agregar(Empleados objeto)
        {
            Listaempleados.Add(objeto);
        }

        public bool Borrar(int id)
        {
            return Listaempleados.Remove(BuscarId(id));
        }

        public List<Empleados> Buscar(string filtro)
        {
            return Listaempleados.Where(e => e.Nombrecompleto().Contains(filtro)).ToList();
        }

        public Empleados BuscarId(int id)
        {
            return Listaempleados.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
