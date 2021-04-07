using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (var element in input)
                {
                    elements.Add(element);
                }
            }

            foreach (var element in elements)
            {
                Console.Write(element + " ");
            }
        }
    }
}
