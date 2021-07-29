using Custom_DI_Workshop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
