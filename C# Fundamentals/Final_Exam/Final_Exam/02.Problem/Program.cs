using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^(\$|%)([A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    int firstNum = int.Parse(match.Groups[3].Value);
                    int secondNum = int.Parse(match.Groups[4].Value);
                    int thirdNum = int.Parse(match.Groups[5].Value);

                    char firstChar = (char)firstNum;
                    char secondChar = (char)secondNum;
                    char thirdChar = (char)thirdNum;


                    StringBuilder sb = new StringBuilder();

                    sb.Append(firstChar);
                    sb.Append(secondChar);
                    sb.Append(thirdChar);

                    Console.WriteLine($"{tag}: {sb}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
