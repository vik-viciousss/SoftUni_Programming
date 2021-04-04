using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimentions[0];
            int m = dimentions[1];

            char[,] matrix = new char[n, m];

            string letters = Console.ReadLine();

            Queue<char> lettersQueue = new Queue<char>(letters);

            for (int row = 0; row < n; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < m; col++)
                    {
                        char currChar = lettersQueue.Dequeue();
                        matrix[row, col] = currChar;
                        lettersQueue.Enqueue(currChar);
                    }
                }
                if (row % 2 != 0)
                {
                    for (int col = m - 1; col >= 0; col--)
                    {
                        char currChar = lettersQueue.Dequeue();
                        matrix[row, col] = currChar;
                        lettersQueue.Enqueue(currChar);
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
