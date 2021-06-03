using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
