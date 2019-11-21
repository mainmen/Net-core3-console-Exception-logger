using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exceptions
{
    public class FileSystemException : Exception
    {
        public FileSystemException(string message): base(message)
        {

        }
    }
}
