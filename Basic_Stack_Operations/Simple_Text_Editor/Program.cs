using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            Stack<string> changes = new Stack<string>();
            Stack<string> lastCommands = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "1")
                {
                    string textToAdd = command[1];
                    sb.Append(textToAdd);
                    changes.Push(textToAdd);
                    lastCommands.Push(command[0]);
                }
                else if (command[0] == "2")
                {
                    int count = int.Parse(command[1]);
                    int startIndex = sb.Length - count;

                    string removed = sb.ToString().Substring(startIndex);

                    sb.Remove(startIndex, count); 

                    changes.Push(removed.ToString());
                    lastCommands.Push(command[0]);
                }
                else if (command[0] == "3")
                {
                    int charCounter = int.Parse(command[1]);
                    Console.WriteLine(sb[charCounter - 1]);
                }
                else if (command[0] == "4")
                {
                    if (lastCommands.Peek() == "1")
                    {
                        lastCommands.Pop();
                        string textToRemove = changes.Pop();
                        int startIndex = sb.Length - textToRemove.Length;
                        sb.Remove(startIndex, textToRemove.Length);
                    }
                    else if (lastCommands.Peek() == "2")
                    {
                        lastCommands.Pop();
                        string textToAddBack = changes.Pop();
                        sb.Append(textToAddBack);
                    }
                }
            }
        }
    }
}
