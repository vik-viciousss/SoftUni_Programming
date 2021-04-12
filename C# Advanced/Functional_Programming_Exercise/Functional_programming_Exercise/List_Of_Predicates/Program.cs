using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> numbers = Enumerable.Range(1, end).ToList();

            foreach (var num in numbers)
            {
                if (dividers.All(d => num % d == 0))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
