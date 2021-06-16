using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Feline
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1.00;

        private static HashSet<string> allowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, allowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
