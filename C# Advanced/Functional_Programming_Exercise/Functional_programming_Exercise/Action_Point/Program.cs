
using System;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> namePrinter = (name) =>
            {
                Console.WriteLine($"{name}");
            };

            foreach (var name in names)
            {
                namePrinter(name);
            }
        }
    }
}
