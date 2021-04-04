using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimentions[0];
            int m = dimentions[1];
            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = -1;
            int maxColIndex = -1;

            for (int row = 0; row < n - 2; row++)
            {
                for (int col = 0; col < m - 2; col++)
                {
                    int sum = matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row, col + 2];

                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];
                    sum += matrix[row + 1, col + 2];

                    sum += matrix[row + 2, col];
                    sum += matrix[row + 2, col + 1];
                    sum += matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRowIndex; row <= maxRowIndex + 2; row++)
            {
                for (int col = maxColIndex; col <= maxColIndex + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
