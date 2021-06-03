using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Used
{
    public interface IPet : IBirthable
    {
        string Name { get; }
    }
}
