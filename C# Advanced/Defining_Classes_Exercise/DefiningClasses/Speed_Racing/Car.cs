using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
            this.DistanceTraveled = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double DistanceTraveled { get; set; }

        public void DriveCheck(int currDistance)
        {
            if (this.FuelAmount >= this.FuelConsumptionPerKilometer * currDistance)
            {
                this.FuelAmount -= this.FuelConsumptionPerKilometer * currDistance;
                this.DistanceTraveled += currDistance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
