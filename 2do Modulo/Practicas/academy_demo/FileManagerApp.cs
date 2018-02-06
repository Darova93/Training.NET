using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace academy_demo
{
    public class FileManagerApp
    { 
        private readonly FileManager _fileManager;

        public FileManagerApp(FileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public string ProcessFile(string path)
        {
            if (_fileManager.CanRead(path))
            {
                string content = _fileManager.Read(path);

                return content;
            }

            return null;
            
        }
    }

}
