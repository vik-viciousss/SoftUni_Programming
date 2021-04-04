using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int row = 0; row < n - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (command[0] == "Add")
                {
                    if (IsValidIndex(matrix, row, col))
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (IsValidIndex(matrix, row, col))
                    {
                        matrix[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(double[][] matrix, int row, int col)
        {
            bool IsValid = row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
            return IsValid;
        }
    }
}
