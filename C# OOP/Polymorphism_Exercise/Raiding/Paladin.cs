using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int BasePower = 100;

        public Paladin(string name) 
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {this.Name} healed for {this.Power}";
        }
    }
}
