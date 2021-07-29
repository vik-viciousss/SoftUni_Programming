using Custom_DI_Workshop.Contracts;
using Custom_DI_Workshop.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;

        [Inject]
        public Engine(ILogger logger, IReader reader)
        {
            this.logger = logger;
            this.reader = reader;
        }

        public void Start()
        {
            logger.log("Game started");

            reader.ReadKey();
            reader.ReadLine();
        }

        public void End()
        {
            logger.log("Game ended");
        }
    }
}
