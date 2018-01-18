using System;
using ClassLibrary1;

namespace Numeroprimo
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroinicial = -5, numerofinal = 1000, i;
            string numero;

            for (i = numeroinicial; i <= numerofinal; i++)
            {   
                if (divisiones.EsPrimo(i)==1)
                    {
                        numero = Convert.ToString(i);
                        Console.Write(numero + " ");
                    }
            }

            Console.ReadKey();
        }
    }
}