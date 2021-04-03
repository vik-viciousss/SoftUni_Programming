using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Stack<int> bracketsIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketsIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = bracketsIndexes.Pop();
                    int endIndex = i;

                    string expression = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(expression);
                }
            }
        }
    }
}
