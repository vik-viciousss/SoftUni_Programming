using SOLID_Exercise.Appenders;
using SOLID_Exercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Error(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Info, message);
        }

        public void Info(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Info, message);
        }
    }
}
