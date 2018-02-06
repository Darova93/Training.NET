using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace academy_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["path"];

                FileManager fileManager = new TextFileManager();

                FileManagerApp app = new FileManagerApp(fileManager);

                string content = app.ProcessFile(path);

                Console.WriteLine($"File Content {content}");

                Console.ReadLine();
            }
            catch (FileManagerException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
            
        }
    }
}
