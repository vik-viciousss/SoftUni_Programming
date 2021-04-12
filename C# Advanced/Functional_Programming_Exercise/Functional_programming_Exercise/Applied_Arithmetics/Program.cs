using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Action<List<int>> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            while (command != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    Func<int, int> arithmeticFunc = GetFunction(command);
                    numbers = numbers.Select(arithmeticFunc).ToList();
                }

                command = Console.ReadLine();
            }
        }

        static Func<int, int> GetFunction(string command)
        {
            switch (command)
            {
                case "add":
                    return num => num + 1;
                case "multiply":
                    return num => num * 2;
                case "subtract":
                    return num => num - 1;
                default:
                    return numbers => numbers;
            }
        }
    }
}
