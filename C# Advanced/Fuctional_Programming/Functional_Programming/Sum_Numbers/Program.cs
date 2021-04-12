﻿using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSumAndCount(int.Parse, a => a.Length, a => a.Sum());

        }

        static void PrintSumAndCount(Func<string, int> parser, Func<int[], int> countGetter, Func<int[], int> sumGetter)
        {
            int[] array = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();

            Console.WriteLine(countGetter(array));
            Console.WriteLine(sumGetter(array));
        }
    }
}
