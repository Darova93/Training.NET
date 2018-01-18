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
            int longitud, contador=0, comparacion, i;
            string palabra, sinespacios;
            Console.WriteLine("Escribe la palabra: ");                  
            palabra = Console.ReadLine();                               //Lee la palabra
            sinespacios = palabra.Replace(" ", "");                     //Quita los espacios
            longitud = (sinespacios.Length - 1) / 2;
            for (i=0; i <= longitud; i++)                               //Va hasta la mitad de la palabra
                {
                    comparacion = sinespacios.Length-1-i;
                    if (sinespacios[i]==sinespacios[comparacion])                 //Compara dos letras
                    {
                        contador++;
                    }
                }
            if (contador >= longitud+1)                                   //Resultado
                Console.WriteLine("Si es un palindromo");
            else
                Console.WriteLine("No es un palindromo");
            
            Console.ReadKey();
        }
    }
}
