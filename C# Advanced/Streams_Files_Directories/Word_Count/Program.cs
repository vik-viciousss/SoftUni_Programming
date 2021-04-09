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
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            using (StreamReader readerWords = new StreamReader("../../../words.txt"))
            {
                using (StreamReader readerText = new StreamReader("../../../text.txt"))
                {
                    //string[] words = readerWords.ReadToEnd().Split();
                    //string text = readerText.ReadToEnd();

                    string[] lineWords = readerWords.ReadLine().ToLower().Split();
                    string[] lineText = readerText.ReadToEnd().ToLower().Split(new[] { " ", ". ", ", ", "-", "...", "?! ", "? ", "." }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in lineWords)
                    {
                        foreach (var text in lineText)
                        {
                            if (word == text)
                            {
                                if (!wordsCount.ContainsKey(word))
                                {
                                    wordsCount.Add(word, 0);
                                }

                                wordsCount[word]++;
                            }
                        }
                    }
                }

                Dictionary<string, int> orderedWordsCount = wordsCount.OrderByDescending(kvp => kvp.Value).ToDictionary(k => k.Key, v => v.Value);

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    foreach (var word in orderedWordsCount)
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
