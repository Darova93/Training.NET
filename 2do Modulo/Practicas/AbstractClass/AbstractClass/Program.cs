using System;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Square sq = new Square(12);
            Console.WriteLine("Area of the square = {0}", sq.Area());
            Console.ReadKey();
        }
    }
}
