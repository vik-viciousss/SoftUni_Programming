using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
