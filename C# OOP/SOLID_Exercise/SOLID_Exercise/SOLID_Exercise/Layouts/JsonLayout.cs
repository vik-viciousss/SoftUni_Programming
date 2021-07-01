using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Template
        {
            get
            {
                return @"""log"": {{
                        ""date"": ""{0}"",
                        ""level"": ""{1}"",
                        ""message"": ""{2}""
                        }}," + Environment.NewLine;
            }
        }
    }
}
