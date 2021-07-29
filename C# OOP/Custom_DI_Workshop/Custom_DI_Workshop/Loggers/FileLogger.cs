using Custom_DI_Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Custom_DI_Workshop.Loggers
{
    class FileLogger : ILogger
    {
        private string path;

        public FileLogger(string path)
        {
            this.path = path;
        }


        public void log(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../logs.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
