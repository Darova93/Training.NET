using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Manejador
    {
        List<Figura> TodaslasFiguras;

        public Manejador()
        {
            TodaslasFiguras = new List<Figura>();
        }

        public void AgregaFigura(Figura NuevaFigura)
        {
            TodaslasFiguras.Add(NuevaFigura);
        }

        public int CuantasTengo()
        {
            return TodaslasFiguras.Count;
        }

        public List<Figura> DameTriangulos()
        {
            List<Figura> ListaTriangulos = new List<Figura>();
            foreach (Figura EnlaQueVoy in TodaslasFiguras)
            {
                if (EnlaQueVoy is Triangulo)
                {
                    ListaTriangulos.Add(EnlaQueVoy);
                }
            }
            return ListaTriangulos;

        }

        public void WhiteWashFiguras()
        {
            //foreach (Figura EnLaQueVoy in TodaslasFiguras)
            //{
            //    EnLaQueVoy._color = Color.White;
            //}
            //No sirve, no se puede cambiar la referencia(TodaslasFiguras)

            for (int i = 0; i < TodaslasFiguras.Count; i++)
            {
                TodaslasFiguras[i]._color = Color.White;
            }

            TodaslasFiguras.ForEach(x => x._color = Color.White);
            bool result = TodaslasFiguras.All(x => x._color == Color.White);
            List<Figura> resultado = TodaslasFiguras.Where(x => x.Area() > 5).ToList();
            List<Figura> resultado2 = TodaslasFiguras.FindAll(delegate (Figura a) { return a.Area() > 5; });

        }

        public List<Figura> OrderByArea()
        {
            TodaslasFiguras.Sort(delegate (Figura a, Figura b)
            {
                return a.Area().CompareTo(b.Area());
            });

            return TodaslasFiguras;

            //TodaslasFiguras.OrderBy(x => x.Area()).ThenBy(x=> x._color).ToList();
        }

        public List<Figura> TypesOrderByArea(string tipo)
        {

            return TodaslasFiguras
                .Where( x => x.Tipo == tipo)
                .OrderBy( y => y.Area())
                .ToList();

        }

    }
}
