using SOLID_Exercise.Appenders;
using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using SOLID_Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    //does the same as:
                    //appender.ReportLevel = reportLevel;
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                default:
                    throw new ArgumentException($"{type} is invalid Appender type");
            }

            return appender;
        }
    }
}
