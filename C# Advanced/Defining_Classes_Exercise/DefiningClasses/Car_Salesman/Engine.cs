using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Salesman
{
    public class Engine
    {
        public Engine()
        {
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public Engine(string model, string enginePower) : this()
        {
            this.Model = model;
            this.EnginePower = enginePower;
        }

        public Engine(string model, string enginePower, string displacement) : this(model, enginePower)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, string enginePower, string displacement, string efficiency) : this(model, enginePower, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public string EnginePower { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string result = $"  {this.Model}:\n" +
                $"    Power: {this.EnginePower}\n" +
                $"    Displacement: {this.Displacement}\n" +
                $"    Efficiency: {this.Efficiency}";
            return result;
        }
    }
}
