using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            Console.Write("Hola, ¿Cómo te llamas? \nSoy: ");
            nombre = Console.ReadLine();
            Console.Write("Mucho gusto " + nombre + ".");    
            Console.ReadKey();
        }
    }
}
