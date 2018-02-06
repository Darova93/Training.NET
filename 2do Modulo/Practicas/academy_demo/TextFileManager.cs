using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace academy_demo
{
    public class TextFileManager : FileManager
    {
        public bool CanRead(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;

            if (!System.IO.File.Exists(path)) return false;

            return true;
        }

        public string Read(string path)
        {

            if (path.Length > 20)
            {
                throw new FileManagerException("Error!!!"); 
            }

            string content = System.IO.File.ReadAllText(path);

            return content;
        }
              

    }
}
