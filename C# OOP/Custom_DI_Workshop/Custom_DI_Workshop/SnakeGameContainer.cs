using Custom_DI_Workshop.Contracts;
using Custom_DI_Workshop.DI.Containers;
using Custom_DI_Workshop.Loggers;
using Custom_DI_Workshop.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            CreateMapping<ILogger, FileLogger>(() => new FileLogger("../../../logs.txt"));
            CreateMapping<IReader, ConsoleReader>();
        }
    }
}
