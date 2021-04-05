using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string numberPattern = @"[\d]";
            string emojiPattern = @"((:{2})|(\*{2}))[A-Z][a-z]{2,}\1";

            Regex numberRegex = new Regex(numberPattern);
            Regex emojiRegex = new Regex(emojiPattern);

            MatchCollection numbersCollection = numberRegex.Matches(text);
            long coolTreshold = 1;

            foreach (Match match in numbersCollection)
            {
                coolTreshold *= int.Parse(match.ToString());
            }

            MatchCollection emojiCollection = emojiRegex.Matches(text);

            List<string> emojies = new List<string>();
            int emojiCount = 0;

            //foreach (Match item in emojiCollection)
            //{
            //    long coolIndex = item.Value.Substring(2, item.Value.Length - 4).ToCharArray().Sum(x => (int)x);

            //    if (coolIndex > coolTreshold)
            //    {
            //        emojies.Add(item.Value);
            //    }

            //    emojiCount++;
            //}

            //Console.WriteLine($"Cool threshold: {coolTreshold}");
            //Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");

            //foreach (var emoji in emojies)
            //{
            //    Console.WriteLine(emoji);
            //}

            foreach (Match match in emojiCollection)
            {
                int coolness = 0;

                foreach (var ch in match.Value)
                {
                    if (char.IsLetter(ch))
                    {
                        coolness += ch;
                    }

                }

                if (coolness > coolTreshold)
                {
                    emojies.Add(match.Value);
                }

                emojiCount++;
            }

            Console.WriteLine($"Cool threshold: {coolTreshold}");

            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");

            foreach (var emoji in emojies)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
