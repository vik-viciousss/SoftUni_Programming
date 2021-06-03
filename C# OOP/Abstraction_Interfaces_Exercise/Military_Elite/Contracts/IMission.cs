using Military_Elite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState MissionState { get; }

        void CompleteMission();
    }
}
