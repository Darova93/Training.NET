using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
        public class Cuadrado : Figura
        {
            float _lado;
            string _tipo = "Square";

            public Cuadrado(float lado, Color color)
            {
                this._lado = lado;
                this._color = color;
            }

            public override double Area()
            {
                return _lado * _lado;
            }

        }
}
