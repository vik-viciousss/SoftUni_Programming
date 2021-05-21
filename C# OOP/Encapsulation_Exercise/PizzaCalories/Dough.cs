using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private const string InvalidDoughExceptionMessage = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        { 
            get => this.flourType;
            private set
            {
                var valueAsLower = value.ToLower();
                var allowedValues = new HashSet<string> { "white", "wholegrain" };

                Validator.ThrowIfValueIsNotAllowed(allowedValues, valueAsLower, InvalidDoughExceptionMessage);

                this.flourType = value;
            } 
        }

        public string BakingTechnique 
        { 
            get => this.bakingTechnique; 
            private set
            {
                var valueAsLower = value.ToLower();
                var allowedValues = new HashSet<string> { "crispy", "chewy", "homemade" };

                Validator.ThrowIfValueIsNotAllowed(allowedValues, valueAsLower, InvalidDoughExceptionMessage);

                this.bakingTechnique = value;
            } 
        }

        public int Weight 
        { 
            get => this.weight; 
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight, MaxWeight, value, $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            } 
        }

        public double GetCalories()
        {
            var flourTypeModifier = GetFlourTypeModifier();
            var bakingTechniqueModifier = GetBakingTechniqueModifier();

            return (2 * this.weight) * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var bakingTechniqueLower = bakingTechnique.ToLower();

            if (bakingTechniqueLower == "crispy")
            {
                return 0.9;
            }
            
            if (bakingTechniqueLower == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }

        private double GetFlourTypeModifier()
        {
            var flourTypeLower = flourType.ToLower();

            if (flourTypeLower == "white")
            {
                return 1.5;
            }

            return 1.0;
        }
    }
}
