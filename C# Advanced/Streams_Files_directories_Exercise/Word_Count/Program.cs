using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("../../../words.txt");

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word, 0);
                word.ToLower();
            }

            string text = File.ReadAllText("../../../text.txt");

            string[] textWords = text.Split(new[] { ".", ",", "?", "!", "-", " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(k => k.ToLower()).ToArray();

            foreach (var word in textWords)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            //!!!!!! SMART MOVES
            //!!!!!!
            List<string> actualList = wordsCount.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();
            File.WriteAllLines("../../../actualResults.txt", actualList);

            Dictionary<string, int> orderedWordsCount = wordsCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            //!!!!!! SMART MOVES
            //!!!!!!
            List<string> listToWrite = orderedWordsCount.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();
            File.WriteAllLines("../../../expectedResult.txt", listToWrite);
        }
    }
}
