using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Predicate<int> diveser = num => num % n != 0;

            numbers = numbers.Where(num => diveser(num)).ToList();

            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));
            print(numbers);

        }
    }
}
