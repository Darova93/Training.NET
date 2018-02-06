using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Creador
    {
        public Figura CreaMagicamenteUna(string parametro)
        {
            string[] Parte = parametro.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Figura LaNueva;

            switch (Parte[0])
            {
                case "triangle":
                    {
                        LaNueva = new Triangulo(
                            float.Parse(Parte[1]),
                            float.Parse(Parte[2]),
                            (Color)Enum.Parse(typeof(Color), Parte[3].Trim(), true)
                            );
                    }
                    break;
                case "rectangle":
                    {
                        LaNueva = new Rectangulo(
                            float.Parse(Parte[1]),
                            float.Parse(Parte[2]),
                            (Color)Enum.Parse(typeof(Color), Parte[3].Trim(), true)
                            );
                    }
                    break;
                case "circle":
                    {
                        LaNueva = new Circulo(
                            float.Parse(Parte[1]),
                            (Color)Enum.Parse(typeof(Color), Parte[2].Trim(), true)
                            );
                    }
                    break;
                case "square":
                    {
                        LaNueva = new Cuadrado(
                            float.Parse(Parte[1]),
                            (Color)Enum.Parse(typeof(Color), Parte[2].Trim(), true)
                            );
                    }
                    break;
            }

            return LaNueva;
        }
    }
}
