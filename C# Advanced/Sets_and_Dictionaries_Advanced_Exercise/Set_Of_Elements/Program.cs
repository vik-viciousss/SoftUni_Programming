using System;
using System.Collections.Generic;
using System.Linq;

namespace Set_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = lenghts[0];
            int m = lenghts[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var number in setN)
            {
                if (setM.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
