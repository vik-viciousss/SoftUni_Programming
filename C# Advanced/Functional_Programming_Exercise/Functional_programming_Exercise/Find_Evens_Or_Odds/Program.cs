using System;
using System.Linq;

namespace Find_Evens_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] borders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            Func<int, bool> condition = GetCondition(command);

            Print(borders, condition);
        }

        static Func<int, bool> GetCondition(string command)
        {
            switch (command)
            {
                case "odd":
                    return num => num % 2 != 0;
                case "even":
                    return num => num % 2 == 0;
                default:
                    return null;
            }
        }
        static void Print(int[] borders, Func<int, bool> condition)
        {
            for (int i = borders[0]; i <= borders[1]; i++)
            {
                if (condition(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
