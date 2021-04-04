using System;
using System.Linq;

namespace Sum_Matrx_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            int[] colSums = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }


            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    colSums[col] += matrix[row, col];
                }
            }

            foreach (var sum in colSums)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
