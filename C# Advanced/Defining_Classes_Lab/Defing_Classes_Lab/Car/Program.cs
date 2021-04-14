using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelConsumption, fuelQuantity);

            //var tires = new Tire[]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3)
            //};

            //var engine = new Engine(560, 6300);

            //var car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);

            string input = Console.ReadLine();

            List<Tire[]> tires = new List<Tire[]>();

            while (input != "No more tires")
            {
                double[] tireInfo = input.Split().Select(double.Parse).ToArray();

                
                tires.Add(new Tire[]
                {
                         new Tire((int)tireInfo[0], tireInfo[1]),
                         new Tire((int)tireInfo[2], tireInfo[3]),
                         new Tire((int)tireInfo[4], tireInfo[5]),
                         new Tire((int)tireInfo[6], tireInfo[7]),

                });

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Engine> engines = new List<Engine>();

            while (input != "Engines done")
            {
                double[] engineInfo = input.Split().Select(double.Parse).ToArray();

                engines.Add(new Engine((int)engineInfo[0], engineInfo[1]));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (input != "Show special")
            {
                string[] carInfo = input.Split();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                Engine currEngine = engines[int.Parse(carInfo[5])];
                Tire[] currTires = tires[int.Parse(carInfo[6])];

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, currEngine, currTires));

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                double currPressureSum = 0;

                foreach (var tire in car.Tires)
                {
                    currPressureSum += tire.Pressure;
                }

                if (car.Year >= 2017 && car.Engine.HorsePower >= 330 && (currPressureSum >= 9 || currPressureSum <= 10))
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }

        }

    }

}

