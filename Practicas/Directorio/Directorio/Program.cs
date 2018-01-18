using System;
using Libreriadeclases;
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
            int opcionmenu;
            bool salida=false;

            while (salida==false)
            {
                Console.WriteLine("Bienvenido! Selecciona una opcion del menu");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Consultar informacion de empleado");
                Console.WriteLine("3. Salir");
                opcionmenu = Convert.ToInt32(Console.ReadLine());
                switch
                {
                    case 1:

                }
                Console.ReadKey();
            }
        }
    }
}
