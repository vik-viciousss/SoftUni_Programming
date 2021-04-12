using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minFinder = numbers => numbers.Min();

            Console.WriteLine(minFinder(numbers));
        }
    }
}
