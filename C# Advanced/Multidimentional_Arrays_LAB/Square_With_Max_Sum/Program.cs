using System;
using System.Linq;

namespace Square_With_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int squareSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (squareSum > maxSum)
                    {
                        maxSum = squareSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = maxSumRow; row < maxSumRow+2; row++)
            {
                for (int col = maxSumCol; col < maxSumCol+2; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
