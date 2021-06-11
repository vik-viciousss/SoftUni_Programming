using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carData[1]);
            double carFuelConsumption = double.Parse(carData[2]);
            double carTankCapacity = double.Parse(carData[3]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckData = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckData[1]);
            double truckFuelConsumption = double.Parse(truckData[2]);
            double truckTankCapacity = double.Parse(truckData[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busData = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busData[1]);
            double busFuelConsumption = double.Parse(busData[2]);
            double busTankCapacity = double.Parse(busData[3]);
            var bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string command = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                if (command == "Drive" && vehicleType == "Car")
                {
                    double distance = double.Parse(cmdArgs[2]);

                    if (car.Drive(distance) == 0)
                    {
                        Console.WriteLine($"{nameof(Car)} travelled {distance} km");
                    }
                    else if(car.Drive(distance) == -1)
                    {
                        Console.WriteLine($"{nameof(Car)} needs refueling");
                    }
                }
                else if (command == "Drive" && vehicleType == "Truck")
                {
                    double distance = double.Parse(cmdArgs[2]);

                    if (truck.Drive(distance) == 0)
                    {
                        Console.WriteLine($"{nameof(Truck)} travelled {distance} km");
                    }
                    else if (truck.Drive(distance) == -1)
                    {
                        Console.WriteLine($"{nameof(Truck)} needs refueling");
                    }
                }
                else if (command == "Drive" && vehicleType == "Bus")
                {
                    double distance = double.Parse(cmdArgs[2]);

                    if (bus.DriveWithPeople(distance) == 0)
                    {
                        Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
                    }
                    else if (bus.DriveWithPeople(distance) == -1)
                    {
                        Console.WriteLine($"{nameof(Bus)} needs refueling");
                    }
                }
                else if (command == "DriveEmpty" && vehicleType == "Bus")
                {
                    double distance = double.Parse(cmdArgs[2]);

                    if (bus.Drive(distance) == 0)
                    {
                        Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
                    }
                    else if (bus.Drive(distance) == -1)
                    {
                        Console.WriteLine($"{nameof(Bus)} needs refueling");
                    }
                }
                else if (command == "Refuel" && vehicleType == "Car")
                {
                    double fuel = double.Parse(cmdArgs[2]);

                    if (fuel <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }

                    car.Refuel(fuel);
                }
                else if (command == "Refuel" && vehicleType == "Truck")
                {
                    double fuel = double.Parse(cmdArgs[2]);

                    if (fuel <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }

                    truck.Refuel(fuel);
                }
                else if (command == "Refuel" && vehicleType == "Bus")
                {
                    double fuel = double.Parse(cmdArgs[2]);

                    if (fuel <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }

                    bus.Refuel(fuel);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
