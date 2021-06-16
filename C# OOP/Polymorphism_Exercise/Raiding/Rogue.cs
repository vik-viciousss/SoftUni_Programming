using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int BasePower = 80;

        public Rogue(string name)
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
