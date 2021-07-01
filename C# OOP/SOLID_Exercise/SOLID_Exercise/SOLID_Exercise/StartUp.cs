using SOLID_Exercise.Appenders;
using SOLID_Exercise.Core;
using SOLID_Exercise.Core.Factories;
using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using SOLID_Exercise.Loggers;
using System;
using System.Collections.Generic;

namespace SOLID_Exercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();

            IEngine engine = new Engine(appenderFactory, layoutFactory);

            engine.Run();
            
        }
    }
}
