using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(input[i]);
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                string action = command[0].ToLower();

                if (action == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (action == "remove")
                {
                    int count = int.Parse(command[1]);

                    if (count > numbers.Count)
                    {
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            numbers.Push(numbers.Sum());

            Console.WriteLine($"Sum: {numbers.Pop()}");
        }
    }
}
