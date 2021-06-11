using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        double consumptionIncrease = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, tankCapacity)
        {
            this.FuelConsumptionInLitersPerKilometer = fuelConsumption + consumptionIncrease;
        }
    }
}
