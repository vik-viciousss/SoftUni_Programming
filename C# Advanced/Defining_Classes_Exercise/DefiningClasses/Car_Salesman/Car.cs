using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Car_Salesman
{
    public class Car
    {
        public Car()
        {
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, string engineModel, List<Engine> engines) : this()
        {
            this.Model = model;
            this.CarEngine = engines.Single(e => e.Model == engineModel);
        }

        public Car(string model, string engineModel, List<Engine> engines, string weight) : this (model, engineModel, engines)
        {
            this.Weight = weight;
        }

        public Car(string model, string engineModel, List<Engine> engines, string weight, string color) : this(model, engineModel, engines, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine CarEngine { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            string result = $"{this.Model}:\n{CarEngine.ToString()}\n" +
                $"  Weight: {this.Weight}\n" +
                $"  Color: {this.Color}";
            return result;
        }
    }
}
