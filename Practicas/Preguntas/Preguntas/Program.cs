using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preguntas
{
    class Program
    {
        static void Main(string[] args)
        {
            int id=0, menuoption=0;
            bool exit==false;
            Console.WriteLine("Welcome! Select one of the following options");
            while exit == false
            {
                Console.Clear();
                Console.WriteLine(id + " Questions added");
                Console.WriteLine("1. Add question");
                Console.WriteLine("2. Exit");
                menuoption = Convert.ToInt32(Console.ReadLine());
                switch(menuoption)
                {
                    case 1:
                        Question.AddQuestion(id);
                        break;
                    case 2:
                        exit = true;
                        break;
                    default
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }

        }
    }
}
