using Custom_DI_Workshop.Contracts;
using Custom_DI_Workshop.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop.Readers
{
    public class ConsoleReader : IReader
    {
        private ILogger logger;

        [Inject]
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;
        }

        public string ReadKey()
        {
            logger.log("Reading key");

            return "";
        }

        public string ReadLine()
        {
            logger.log("Reading line");

            return "";
        }
    }
}
