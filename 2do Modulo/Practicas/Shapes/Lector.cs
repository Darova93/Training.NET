using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Lector
    {
        public static string[] ReadFile(string fileName)
        {
            string[] lines;
            using (StreamReader reader = new StreamReader(fileName))
            {
                lines = reader.ReadToEnd().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                reader.Close();
            }
            return lines;
        }
    }
}
