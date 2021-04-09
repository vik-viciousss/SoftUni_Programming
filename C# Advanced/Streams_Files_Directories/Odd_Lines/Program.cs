using System;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string currentRow = reader.ReadLine();
                int counter = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (currentRow != null)
                    {
                        if (counter % 2 == 1)
                        {
                            Console.WriteLine(currentRow);
                            writer.WriteLine(currentRow);

                        }

                        currentRow = reader.ReadLine();
                        counter++;
                    }
                }

            }
        }
    }
}
