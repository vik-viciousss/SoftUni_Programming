using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
