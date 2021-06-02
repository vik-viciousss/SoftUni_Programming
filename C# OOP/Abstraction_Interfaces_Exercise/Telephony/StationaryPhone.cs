using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
