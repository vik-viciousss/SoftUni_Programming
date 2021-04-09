using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../text.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int counter = 0;

                StringBuilder sb = new StringBuilder();

                while (line != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        char[] chars = new char[] { '-', ',', '.', '!', '?' };

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == '-' || line[i] == ',' || line[i] == '.' || line[i] == '!' || line[i] == '?' )
                            {
                                sb.Append('@');
                            }
                            else
                            {
                                sb.Append(line[i]);
                            }
                        }

                        string replacedLine = sb.ToString();
                        sb.Clear();

                        List<string> reversedLine = replacedLine.Split().ToList();
                        Stack<string> finalLine = new Stack<string>();

                        for (int i = 0; i < reversedLine.Count; i++)
                        {
                            finalLine.Push(reversedLine[i]);
                        }

                        string poped = finalLine.Pop();

                        while (true)
                        {
                            Console.Write($"{poped} ");

                            if (finalLine.Count == 0)
                            {
                                break;
                            }
                            poped = finalLine.Pop();
                        }
                    }
                    Console.WriteLine();
                    line = reader.ReadLine();
                }
            }
        }
    }
}
