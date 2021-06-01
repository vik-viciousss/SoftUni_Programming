using System;
using System.IO;
using System.Linq;

namespace _02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currLine = lines[i];

                int lettersCount = CountOfLetters(currLine);
                int punctionalCount = PunctionalCharCount(currLine);

                lines[i] = $"Line {i + 1} : {currLine} ({lettersCount})({punctionalCount})";
            }

            File.WriteAllLines("../../../output.txt", lines);

        }

        static int PunctionalCharCount(string currLine)
        {
            int count = 0;

            for (int i = 0; i < currLine.Length; i++)
            {
                char currChar = currLine[i];

                if (char.IsPunctuation(currChar))
                {
                    count++;
                }
            }

            return count;
        }

        static int CountOfLetters(string currLine)
        {
            int count = 0;

            for (int i = 0; i < currLine.Length; i++)
            {
                char currChar = currLine[i];

                if (char.IsLetter(currChar))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
