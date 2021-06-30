using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

    }
}
