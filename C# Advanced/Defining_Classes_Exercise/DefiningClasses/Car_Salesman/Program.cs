using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split();

                string model = engineData[0];
                string enginePower =engineData[1];

                Engine currEngine = new Engine(model, enginePower);

                if (engineData.Length == 3)
                {
                    string displacement = engineData[2];

                    currEngine = new Engine(model, enginePower, displacement);
                }
                else if (engineData.Length == 4)
                {
                    string displacement = engineData[2];
                    string efficiency = engineData[3];

                    currEngine = new Engine(model, enginePower, displacement, efficiency);
                }

                engines.Add(currEngine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                string engineModel = carData[1];

                Car currCar = new Car(model, engineModel, engines);

                if (//carData.Length == 3)
                {
                    string weight = carData[2];
                    currCar = new Car(model, engineModel, engines, weight);
                }
                else if (//carData.Length == 4)
                {
                    string weight = carData[2];
                    string color = carData[3];
                    currCar = new Car(model, engineModel, engines, weight, color);
                }

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

            //program can't determine whether the trird argument is weight or color/ displacement or efficiency
            //need to make different check for which ctor to use
            //which variable is which one from the input
            //validation inside the prop: set weight if()else => set color


        }
    }
}
