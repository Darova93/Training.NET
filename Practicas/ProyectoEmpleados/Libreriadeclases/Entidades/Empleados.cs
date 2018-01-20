using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreriadeclases.Entidades
{
    public class Empleados
    {
        // Atributos de la clase
        public int Id { get; set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public Genero Genero { get; set; }
        public DateTime Fechanac { get; set; }
        public string Nombrecompleto { get { return Nombre + "" + Apellidop + "" + Apellidom; } }

        //Constructor de clase

        public Empleados(int id, int edad, string nombre, string apellidop, string apellidom, Genero genero, DateTime fechanac)
        {
            Id = id;
            Edad = edad;
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
            Fechanac = fechanac;
            Genero = genero;
        }

        //Metodos de la clase

    }
}
