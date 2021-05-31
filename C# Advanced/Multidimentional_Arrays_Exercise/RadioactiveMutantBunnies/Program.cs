using System;
using System.Linq;

namespace RadioactiveMutantBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] lair = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                char[] rowData = input.ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = rowData[col];

                    if (rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();
            bool hasWon = true;

            foreach (char item in commands)
            {
                bool canMove = false;

                try
                {
                    canMove = TryMovePlayer(item, lair, playerRow, playerCol);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "row-1")
                    {
                        playerRow--;
                    }
                    else if (ex.Message == "row+1")
                    {
                        playerRow++;
                    }
                    else if (ex.Message == "col-1")
                    {
                        playerCol--;
                    }
                    else if (ex.Message == "col+1")
                    {
                        playerCol++;
                    }

                    hasWon = false;
                    break;
                }

                if (canMove)
                {
                    if (item == 'U')
                    {
                        lair[playerRow - 1, playerCol] = 'P';
                        lair[playerRow, playerCol] = '.';
                        playerRow--;
                    }
                    else if (item == 'D')
                    {
                        lair[playerRow + 1, playerCol] = 'P';
                        lair[playerRow, playerCol] = '.';
                        playerRow++;
                    }
                    else if (item == 'L')
                    {
                        lair[playerRow, playerCol - 1] = 'P';
                        lair[playerRow, playerCol] = '.';
                        playerCol--;
                    }
                    else
                    {
                        lair[playerRow, playerCol + 1] = 'P';
                        lair[playerRow, playerCol] = '.';
                        playerCol++;
                    }

                }
                else
                {
                    hasWon = true;
                    break;
                }


                try
                {
                    
                    lair = SpreadBunnies(lair, rows, cols);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "row-1")
                    {
                        playerRow--;
                    }
                    else if (ex.Message == "row+1")
                    {
                        playerRow++;
                    }
                    else if (ex.Message == "col-1")
                    {
                        playerCol--;
                    }
                    else if (ex.Message == "col+1")
                    {
                        playerCol++;
                    }

                    hasWon = false;
                    break; 
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(lair[row, col] + " ");
                }

                Console.WriteLine();
            }

            if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }

        static bool TryMovePlayer(char direction, char[,] lair, int playerRow, int playerCol)
        {
            if (direction == 'U')
            {
                if (playerRow - 1 >= 0)
                {
                    if (lair[playerRow - 1, playerCol] == 'B')
                    {
                        throw new Exception("row-1");
                    }

                    return true;
                }

                return false;
            }
            else if (direction == 'D')
            {
                if (playerRow + 1 < lair.GetLength(0))
                {
                    if (lair[playerRow + 1, playerCol] == 'B')
                    {
                        throw new Exception("row+1");
                    }

                    return true;
                }

                return false;
            }
            else if (direction == 'L')
            {
                if (playerCol - 1 >= 0)
                {
                    if (lair[playerRow, playerCol - 1] == 'B')
                    {
                        throw new Exception("col-1");
                    }

                    return true;
                }

                return false;
            }
            else 
            {
                if (playerCol + 1 < lair.GetLength(1))
                {
                    if (lair[playerRow, playerCol + 1] == 'B')
                    {
                        throw new Exception("col+1");
                    }

                    return true;
                }

                return false;
            }
        }

        static char[,] SpreadBunnies(char[,] lair, int rows, int cols)
        {
            char[,] updatedLair = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    updatedLair[row, col] = lair[row, col];
                }
            }


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        if (IsInMatrix(rows, cols, row - 1, col))
                        {
                            if (lair[row - 1, col] == 'P')
                            {
                                updatedLair[row - 1, col] = 'B';
                                throw new Exception("row-1");
                            }

                            updatedLair[row - 1, col] = 'B';
                        }

                        if (IsInMatrix(rows, cols, row + 1, col))
                        {
                            if (lair[row + 1, col] == 'P')
                            {
                                updatedLair[row + 1, col] = 'B';
                                throw new Exception("row+1");
                            }

                            updatedLair[row + 1, col] = 'B';
                        }

                        if (IsInMatrix(rows, cols, row, col - 1))
                        {
                            if (lair[row, col - 1] == 'P')
                            {
                                updatedLair[row, col - 1] = 'B';
                                throw new Exception("col-1");
                            }

                            updatedLair[row, col - 1] = 'B';
                        }

                        if (IsInMatrix(rows, cols, row, col + 1))
                        {
                            if (lair[row, col + 1] == 'P')
                            {
                                updatedLair[row, col + 1] = 'B';
                                throw new Exception("col+1");
                            }

                            updatedLair[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return updatedLair;
        }

        static bool IsInMatrix(int rows, int cols, int currRow, int currCow)
        {
            return currRow >= 0 && currRow < rows && currCow >= 0 && currCow < cols;
        }

    }
}
