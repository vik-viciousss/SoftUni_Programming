using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                double tire1Pressure = double.Parse(carData[5]);
                int tire1Age = int.Parse(carData[6]);
                double tire2Pressure = double.Parse(carData[7]);
                int tire2Age = int.Parse(carData[8]);
                double tire3Pressure = double.Parse(carData[9]);
                int tire3Age = int.Parse(carData[10]);
                double tire4Pressure = double.Parse(carData[11]);
                int tire4Age = int.Parse(carData[12]);

                Car currCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> fragileCars = cars.Where(c => c.CarCargo.CargoType == "fragile").ToList();
                int indexOfFinalCar = 0;

                List<Car> finalList = new List<Car>();

                foreach (var car in fragileCars)
                {
                    foreach (var tire in car.Tires)
                    {
                        if (tire.TirePressure < 1)
                        {
                            indexOfFinalCar = fragileCars.IndexOf(car);

                            finalList.Add(fragileCars[indexOfFinalCar]);

                            break;
                        }
                    }

                }

                foreach (var car in finalList)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                List<Car> flamableCars = cars
                    .Where(c => c.CarCargo.CargoType == "flamable")
                    .Where(c => c.CarEngine.EnginePower > 250)
                    .ToList();

                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
