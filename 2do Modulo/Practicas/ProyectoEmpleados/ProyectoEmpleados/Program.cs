using System;
using Libreriadeclases.Negocios;
using Libreriadeclases.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directorio
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Empleados> lista = new List<Empleados>();
            EmployeeRepository listaempleados = new EmployeeRepository(lista);

            for (int i = 1; i <= 10; i++)
            {
                listaempleados.Agregar(
                    new Empleados(i
                    , 20 + i * i, "Nombre " + i.ToString()
                    , "Apellido Paterno " + i.ToString()
                    , "Apellido Materno " + i.ToString()
                    , Genero.Hombre
                    , DateTime.Now));
            }

            listaempleados.Borrar(3);
            listaempleados.Borrar(6);
            listaempleados.Borrar(3);
            listaempleados.Borrar(8);


            foreach (Empleados nombre in lista)
            {
                Console.WriteLine(nombre.Id + " " + nombre.Nombrecompleto + " " + nombre.Genero);
            }

            Console.ReadKey();
        }
    }
}
