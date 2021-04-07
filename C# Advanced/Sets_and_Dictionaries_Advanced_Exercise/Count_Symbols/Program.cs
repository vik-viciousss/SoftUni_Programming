using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            foreach (var ch in text)
            {
                if (!chars.ContainsKey(ch))
                {
                    chars.Add(ch, 0);
                }

                chars[ch]++;
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
