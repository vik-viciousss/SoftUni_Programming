using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(number => number + (number * 0.2m))
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }

        }

        static decimal[] Select(decimal[] array, Func<decimal, decimal> tranformer)
        {
            decimal[] newArray = new decimal[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = tranformer(array[i]);
            }

            return newArray;
        }
    }
}
