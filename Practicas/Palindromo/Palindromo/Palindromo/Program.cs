using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            int longitud, i=0, contador=0, b;
            string palabra, sinespacios;
            Console.WriteLine("Escribe la palabra: ");
            palabra = Console.ReadLine();
            sinespacios = palabra.Replace(" ", "");
            longitud = sinespacios.Length - 1;
            while (i<=longitud)
                {
                    b = longitud - i;
                    if (sinespacios[i]==sinespacios[b])
                    {
                        contador = contador + 1;
                    }
                i++;
                }
            if (contador >= longitud)
                Console.WriteLine("Si es un palindromo");
            else
                Console.WriteLine("No es un palindromo");
            
            Console.ReadKey();
        }
    }
}
