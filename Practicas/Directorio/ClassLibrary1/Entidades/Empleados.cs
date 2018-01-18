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
        public bool Sexo { get; set; }
        public Direcciones AgregarDireccion { get; set; }
        public DateTime Fechanac { get; set; }

        //Constructor de clase
        public Empleados()
        {
        }

        public Empleados(int id, int edad, string nombre, string apellidop, string apellidom, bool sexo, Direcciones agregarDireccion, DateTime fechanac)
        {
            Id = id;
            Edad = edad;
            Nombre = nombre;
            Apellidop = apellidop;
            Apellidom = apellidom;
            Sexo = sexo;
            AgregarDireccion = agregarDireccion;
            Fechanac = fechanac;
        }

        //Metodos de la clase

        public string Nombrecompleto (string nombre, string apellidop, string apellidom)
        {
            return this.Nombre + "" + this.Apellidop + "" + this.Apellidom;
        }

    }
}
