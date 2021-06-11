using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private double consumptionIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, tankCapacity)
        {
            this.FuelConsumptionInLitersPerKilometer = fuelConsumption;
        }

        public int DriveWithPeople(double distance)
        {
            double fuelToConsume = distance * (this.FuelConsumptionInLitersPerKilometer + consumptionIncrease);

            if (this.FuelQuantity >= fuelToConsume)
            {
                this.FuelQuantity -= fuelToConsume;
                return 0;
            }

            return -1;
        }
    }
}
