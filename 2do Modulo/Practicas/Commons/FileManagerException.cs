using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class FileManagerException : Exception
    {
        public FileManagerException(string message) : base(message)
        {

        }
        
    }
}
