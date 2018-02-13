using DataAccess.Implementation;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTO;

namespace Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentEF();

            Console.WriteLine("Updating...");
            studentRepository.AddStudent(new StudentDTO { Name = "Pedro", LastName = "Perez", Age = 20, Email = "pedro@gmail.com" });
            Console.WriteLine("Complete.");
            Console.ReadKey();
            Console.WriteLine("Closing...");
        }
    }
}
