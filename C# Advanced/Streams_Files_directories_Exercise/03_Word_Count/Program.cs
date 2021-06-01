﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string word = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()[0].ToLower();

                    if (!wordOccurances.ContainsKey(word))
                    {
                        wordOccurances[word] = 0;
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../actualResult.txt"))
            {
                using (StreamReader reader = new StreamReader("../../../text.txt"))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] words = line.Split().Select(x => x.TrimStart(new char[] { '-', '.', ',', '?', '!' })).Select(x => x.TrimEnd(new char[] { '-', '.', ',', '?', '!' })).Select(x => x.ToLower()).ToArray();

                        foreach (var item in words)
                        {
                            if (wordOccurances.ContainsKey(item))
                            {
                                wordOccurances[item]++;
                            }
                        }

                        line = reader.ReadLine();
                    }

                    foreach (KeyValuePair<string, int> kvp in wordOccurances.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
