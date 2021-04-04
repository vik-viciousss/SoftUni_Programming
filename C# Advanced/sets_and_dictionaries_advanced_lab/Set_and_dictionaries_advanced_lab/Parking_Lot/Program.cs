using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            HashSet<string> parking = new HashSet<string>();

            while (input[0] != "END")
            {
                if (input[0] == "IN")
                {
                    parking.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    parking.Remove(input[1]);
                }


                input = Console.ReadLine().Split(", ");
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            }
        }
    }
}
