using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable
    {
        public void Browse(string website)
        {
            foreach (var item in website)
            {
                if (char.IsDigit(item))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }

            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            
            Console.WriteLine($"Calling... {number}");
        }
    }
}
