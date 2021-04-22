using System;
using System.Linq;

namespace Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(Sum(input));
        }

        static int Sum(int[] array, int index = 0)
        {
            int sum = 0;

            if (index == array.Length - 1)
            {
                return array[index];
            }

            sum = array[index] + Sum(array, index + 1);

            return sum;
        }
    }
}
