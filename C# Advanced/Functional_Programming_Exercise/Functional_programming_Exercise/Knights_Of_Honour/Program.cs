using System;

namespace Knights_Of_Honour
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> namePrinter = (name) => 
            {
                Console.WriteLine($"Sir {name}");
            };

            foreach (var name in names)
            {
                namePrinter(name);
            }
        }
    }
}
