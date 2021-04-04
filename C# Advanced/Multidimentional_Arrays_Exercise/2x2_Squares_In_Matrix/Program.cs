using System;
using System.Linq;

namespace _2x2_Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] matrix = new char[dimentions[0], dimentions[1]];

            for (int row = 0; row < rows; row++)
            {
                char[] rowChars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowChars[col];
                }
            }

            int numberOfSquares = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        numberOfSquares++;
                    }
                }
            }

            Console.WriteLine(numberOfSquares);
        }
    }
}
