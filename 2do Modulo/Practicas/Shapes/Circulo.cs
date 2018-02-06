using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circulo : Figura
    {
        float _radio;
        string _tipo = "Circle";

        public Circulo(float radio, Color color)
        {
            this._radio = radio;
            this._color = color;
        }

        public override double Area()
        {
            return Math.PI * _radio * _radio;
        }

    }
}
