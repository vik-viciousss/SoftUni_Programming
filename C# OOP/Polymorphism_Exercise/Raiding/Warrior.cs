using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int BasePower = 100;

        public Warrior(string name)
            : base(name, BasePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
