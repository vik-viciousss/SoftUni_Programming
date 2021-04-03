using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsGreen = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int timeLeftGreen = secondsGreen;
            int carsPassed = 0;
            bool hasOccured = false;

            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    string currCar = cars.Peek();

                    if (currCar.Length <= timeLeftGreen)
                    {
                        cars.Dequeue();
                        carsPassed++;
                        timeLeftGreen -= currCar.Length;

                        if (cars.Count < 1)
                        {
                            command = Console.ReadLine();
                            timeLeftGreen = secondsGreen;
                        }
                        continue;
                    }
                    else
                    {
                        if (currCar.Length - timeLeftGreen <= freeWindowDuration)
                        {
                            cars.Dequeue();
                            carsPassed++;
                        }
                        else
                        {
                            int charsLeft = currCar.Length - timeLeftGreen - freeWindowDuration - 1;
                            int charIndex = currCar.Length - charsLeft - 1;

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCar} was hit at {currCar[charIndex]}.");
                            hasOccured = true;
                            break;
                        }
                    }
                }

                timeLeftGreen = secondsGreen;
                command = Console.ReadLine();
            }

            if (!hasOccured)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}
