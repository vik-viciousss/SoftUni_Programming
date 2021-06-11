using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value <= this.TankCapacity)
                {
                    this.fuelQuantity = value;
                }
                else
                {
                    this.fuelQuantity = 0;
                }
            }
        }

        public double FuelConsumptionInLitersPerKilometer { get; set; }

        public double TankCapacity { get; set; }


        public int Drive(double distance)
        {
            double fuelToConsume = distance * this.FuelConsumptionInLitersPerKilometer;

            if (this.FuelQuantity >= fuelToConsume)
            {
                this.FuelQuantity -= fuelToConsume;
                return 0;
            }

            return -1;
        }

        public virtual void Refuel(double fuel)
        {
            double tryFuel = fuel + this.FuelQuantity;

            if (tryFuel <= this.TankCapacity)
            {
                this.FuelQuantity += fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }

    }
}
