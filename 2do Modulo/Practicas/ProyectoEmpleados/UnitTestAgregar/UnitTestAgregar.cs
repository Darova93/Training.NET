using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Libreriadeclases.Entidades;
using Libreriadeclases.Negocios;

namespace UnitTest
{
    [TestClass]
    public class UnitTestAgregar
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Empleados> lista = new List<Empleados>();
            EmployeeRepository listaempleados = new EmployeeRepository(lista);

            for (int i = 1; i <= 10; i++)
            {
                listaempleados.Agregar(
                    new Empleados(i
                    , 20 + i * i, "Nombre " + i.ToString()
                    , "Apellido Paterno " + i.ToString()
                    , "Apellido Materno " + i.ToString()
                    , Genero.Hombre
                    , DateTime.Now));
            }
            Assert.AreEqual(10, lista.Count);
        }
    }
}
