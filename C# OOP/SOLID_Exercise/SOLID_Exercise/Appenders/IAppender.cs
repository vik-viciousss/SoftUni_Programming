using SOLID_Exercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public interface IAppender
    {
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
