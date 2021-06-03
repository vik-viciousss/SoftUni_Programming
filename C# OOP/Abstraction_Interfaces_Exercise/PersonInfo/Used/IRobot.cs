using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Used
{
    public interface IRobot : IIdentifiable
    {
        string Model { get; }
    }
}
