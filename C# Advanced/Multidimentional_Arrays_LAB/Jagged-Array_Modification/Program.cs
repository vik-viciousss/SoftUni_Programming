using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[row] = new int[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row > jaggedArray.Length - 1 || row < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().Split();
                    continue;
                }
                else if (col > jaggedArray[row].Length || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine().Split();
                    continue;
                }

                if (command[0] == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
