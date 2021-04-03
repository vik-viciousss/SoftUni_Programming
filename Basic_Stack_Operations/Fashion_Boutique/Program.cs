using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(input);
            int sum = capacity;
            int rackNum = 1;

            while (clothes.Any())
            {
                int currCloth = clothes.Peek();

                if (sum - currCloth > 0)
                {
                    sum -= currCloth;
                    clothes.Pop();
                }
                else if (sum - currCloth == 0)
                {
                    clothes.Pop();
                    
                    if (clothes.Any())
                    {
                        sum = capacity;
                        rackNum++;
                    }
                }
                else
                {
                    rackNum++;
                    sum = capacity - currCloth;
                    clothes.Pop();
                }
            }

            Console.WriteLine(rackNum);
        }
    }
}
