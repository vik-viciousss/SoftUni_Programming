﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = data[0];
            int s = data[1];
            int x = data[2];

            int[] numbersInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>();

            //int smallestNum = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                numbers.Push(numbersInput[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count() < 1) // numbers.Any() 
            {
                Console.WriteLine("0");
            }
            else
            {
                //foreach (var num in numbers)
                //{
                //    if (num < smallestNum)
                //    {
                //        smallestNum = num;
                //    }
                //}

                //Console.WriteLine(smallestNum);

                Console.WriteLine(numbers.Min());
            }
        }
    }
}
