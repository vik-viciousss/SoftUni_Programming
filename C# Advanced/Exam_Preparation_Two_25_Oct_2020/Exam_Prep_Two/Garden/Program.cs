using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimentions[0];
            int m = dimentions[1];

            int[,] garden = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    garden[row, col] = 0;
                }
            }

            string command = Console.ReadLine();
            List<int[]> positions = new List<int[]>();

            while (command != "Bloom Bloom Plow")
            {
                int[] data = command.Split(" ").Select(int.Parse).ToArray();
                int rowToPlant = data[0];
                int colToPlant = data[1];

                if (!AreCoordinatesValid(rowToPlant, colToPlant, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }

                positions.Add(data);

                command = Console.ReadLine();
            }

            foreach (var position in positions)
            {
                int flowerRow = position[0];
                int flowerCol = position[1];

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < m; col++)
                    {
                        if (row == flowerRow && col == flowerCol)
                        {
                            garden = Bloom(row, col, garden);
                            break;
                        }
                    }
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool AreCoordinatesValid(int row, int col, int n, int m)
        {
            if (row < 0 || row >= n)
            {
                return false;
            }

            if (col < 0 || col >= m)
            {
                return false;
            }

            return true;
        }

        public static int[,] Bloom(int row, int col, int[,] garden)
        {
            garden[row, col]++;

            int currRow = row;
            int currCol = col;

            currRow--;
            while (currRow >= 0)
            {
                garden[currRow, col]++;
                currRow--;
            }

            currRow = row;
            currRow++;
            while (currRow < garden.GetLength(0))
            {
                garden[currRow, col]++;
                currRow++;
            }

            currCol--;
            while (currCol >= 0)
            {
                garden[row, currCol]++;
                currCol--;
            }

            currCol = col;
            currCol++;
            while (currCol < garden.GetLength(1))
            {
                garden[row, currCol]++;
                currCol++;
            }

            return garden;
        }
    }
}
