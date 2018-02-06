using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Creador AllMighty = new Creador();
            Manejador Manejador = new Manejador();
            Console.WriteLine("Iniciando magicamente mi lista");

            string[] TodasMisLineas = Lector.ReadFile("shapes.txt");
            //{
            //    "square, 8, red",
            //    "circle, 3, blue",
            //    "triangle, 5, 6, green",
            //    "rectangle, 10, 5, purple"
            //}

            foreach (string linea in TodasMisLineas)
            {
                Manejador.AgregaFigura(AllMighty.CreaMagicamenteUna(linea));
            }

            Console.WriteLine(string.Format("En este momento tengo {0}", Manejador.CuantasTengo()));

            foreach (Figura figure in Manejador.OrderByArea())
            {
                Console.WriteLine(string.Format("Type: {0}, Area: {1}, Color {2}", figure.Tipo, figure.Area(), figure._color));
            }

            Console.WriteLine("Triangle, Rectangle, Circle");
            {

            }

        }
    }
}
