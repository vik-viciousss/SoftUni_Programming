using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message);

            Console.WriteLine(content);
        }
    }
}
