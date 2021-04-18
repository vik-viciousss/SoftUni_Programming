using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> open = new Stack<char>();

            string input = Console.ReadLine();

            foreach (char item in input)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    open.Push(item);
                }
                else
                {
                    if (item == ')' && open.Peek() == '(')
                    {
                        open.Pop();
                    }
                    else if (item == ']' && open.Peek() == '[')
                    {
                        open.Pop();
                    }
                    else if (item == '}' && open.Peek() == '{')
                    {
                        open.Pop();
                    }
                }
            }

            if (open.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
