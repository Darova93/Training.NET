using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public abstract class Figura
    {
        public Color _color { get; set; }
        protected string _tipo;
        public string Tipo { get { return _tipo; } }

        public abstract double Area();
            
    }
}
