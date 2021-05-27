using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int batteries;

        public Tesla(string model, string color, int batteries)
        {
            this.Model = model;
            this.Color = color;
            this.Batteries = batteries;
        }

        public int Batteries
        {
            get => this.batteries;
            private set
            {
                this.batteries = value;
            }
        }
        public string Model
        {
            get => this.model;
            private set
            {
                this.model = value;
            }
        }
        public string Color
        {
            get => this.color;
            private set
            {
                this.color = value;
            }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Batteries} Batteries";
        }
    }
}
