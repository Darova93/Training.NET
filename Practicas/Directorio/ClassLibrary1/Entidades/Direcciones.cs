using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreriadeclases.Entidades
{
    public class Direcciones
    {
        //Atributos de la clase
        public int Id { get; set; }
        public int Codigopostal { get; set; }
        public int Numero { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        //Constructor de clase
        public Direcciones()
        {
        }

        public Direcciones(int id, int codigopostal, int numero, string calle, string colonia, string ciudad, string estado, string pais)
        {
            Id = id;
            Codigopostal = codigopostal;
            Numero = numero;
            Calle = calle;
            Colonia = colonia;
            Ciudad = ciudad;
            Estado = estado;
            Pais = pais;
        }

        //class methods


    }
}
