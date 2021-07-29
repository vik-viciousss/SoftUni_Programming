using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_DI_Workshop.Contracts
{
    public interface IReader
    {
        string ReadKey();
        string ReadLine();
    }
}
