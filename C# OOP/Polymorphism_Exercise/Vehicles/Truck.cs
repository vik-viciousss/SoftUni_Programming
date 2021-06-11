using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double consumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, tankCapacity)
        {
            this.FuelConsumptionInLitersPerKilometer = fuelConsumption + consumptionIncrease;
        }

        public override void Refuel(double fuel)
        {
            double tryFuel = fuel + this.FuelQuantity;

            if (tryFuel <= this.TankCapacity)
            {
                this.FuelQuantity += 0.95 * fuel;
            }
            else
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
        }
    }
}
