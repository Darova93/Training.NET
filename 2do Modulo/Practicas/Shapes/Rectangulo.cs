using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangulo : Figura
    {
        float _base;
        float _altura;
        string _tipo = "Rectangle";

        public Rectangulo(float Base, float altura, Color color)
        {
            this._base = Base;
            this._altura = altura;
            this._color = color;
        }

        public override double Area()
        {
            return _base * _altura;
        }

    }
}
