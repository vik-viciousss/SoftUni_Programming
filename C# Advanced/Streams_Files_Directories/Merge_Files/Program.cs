using System;
using System.IO;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader("../../../FileOne.txt"))
            {
                using (StreamReader readerTwo = new StreamReader("../../../FileTwo.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                    {
                        string firstTextLine = readerOne.ReadLine();
                        string secondTextLine = readerTwo.ReadLine();

                        while (firstTextLine != null || secondTextLine != null)
                        {
                            writer.WriteLine($"{firstTextLine}{Environment.NewLine}{secondTextLine}");

                            firstTextLine = readerOne.ReadLine();
                            secondTextLine = readerTwo.ReadLine();
                        }
                    }
                }
            }


        }
    }
}
