﻿using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using SOLID_Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!this.CanAppend(reportLevel))
            {
                return;
            }

            this.MessagesCount += 1;

            string content = string.Format(this.layout.Template, date, reportLevel, message) +
                Environment.NewLine;

            this.logFile.Write(content);
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
