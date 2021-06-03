using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
