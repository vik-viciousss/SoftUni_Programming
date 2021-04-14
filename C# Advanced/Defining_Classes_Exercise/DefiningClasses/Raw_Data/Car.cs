using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            this.Model = model;

            this.CarEngine = new Engine(engineSpeed, enginePower);

            this.CarCargo = new Cargo(cargoWeight, cargoType);

            this.Tires = new Tire[4]
            {
                new Tire (tire1Pressure, tire1Age),
                new Tire (tire2Pressure, tire2Age),
                new Tire (tire3Pressure, tire3Age),
                new Tire (tire4Pressure, tire4Age),

            };
        }


        public string Model { get; set; }

        public Engine CarEngine { get; set; }

        public Cargo CarCargo { get; set; }

        public Tire[] Tires { get; set; }
    }
}
