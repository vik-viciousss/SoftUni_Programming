using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string currentLine = reader.ReadLine();

                    int counter = 1;
                    
                    while (currentLine != null)
                    {
                        writer.WriteLine($"{counter}. {currentLine}");

                        currentLine = reader.ReadLine();
                        counter++;
                    }
                }
            }


        }
    }
}
