using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinToppings = 0;
        private const int MaxToppings = 10;

        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;

        private string name;
        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;

            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough 
        { 
            get => this.dough; 
            set => this.dough = value; 
        }

        public int NumberOfToppings
        {
            get => this.toppings.Count;
        }

        public double TotalCalories
        {
            get { return this.GetCalories(); }
        }
        

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetCalories():F2} Calories.";
        }
    }
}
