using System;
using System.Collections.Generic;

namespace Speed_Racing
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
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionFor1km = double.Parse(carData[2]);

                Car currCar = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(currCar);
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                string currModel = command[1];
                int currDistance = int.Parse(command[2]);

                foreach (var car in cars)
                {
                    if (car.Model == currModel)
                    {
                        car.DriveCheck(currDistance);

                        break;
                    }
                }

                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
