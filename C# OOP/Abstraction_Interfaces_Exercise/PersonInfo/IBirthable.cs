using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBirthable : IPerson
    {
        string Birthdate { get; }
    }
}
