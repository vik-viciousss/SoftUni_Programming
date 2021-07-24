using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Sandwich : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwitchPrototype Clone()
        {
            string ingredientsList = this.GetIngredientsList();
            Console.WriteLine($"Cloning sandwich with ingredients:" +
                $"{ingredientsList}");

            return this.MemberwiseClone() as SandwitchPrototype;
        }

        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
