using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01_Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charsToReplace = { '-', ',', '.', '!', '?' };
            int count = 0;

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }


                    if (count % 2 == 0)
                    {
                        line = ReplaceAll(charsToReplace, '@', line);
                        line = Reverse(line);
                        Console.WriteLine(line);
                    }

                    count++;
                }
            }
        }

        static string Reverse(string line)
        {
            StringBuilder sb = new StringBuilder();
            string[] word = line.Split().ToArray();

            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(word[word.Length - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }

        static string ReplaceAll(char[] charsToReplace, char v, string line)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (charsToReplace.Contains(currSymbol))
                {
                    sb.Append('@');
                }
                else
                {
                    sb.Append(currSymbol);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
