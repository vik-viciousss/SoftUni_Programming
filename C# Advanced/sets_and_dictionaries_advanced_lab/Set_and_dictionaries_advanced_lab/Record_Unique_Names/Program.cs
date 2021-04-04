﻿using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string currName = Console.ReadLine();

                names.Add(currName);

            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
