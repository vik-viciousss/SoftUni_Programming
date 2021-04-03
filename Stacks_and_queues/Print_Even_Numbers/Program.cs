using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (var num in numbers)
            {
                queue.Enqueue(num);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = queue.Dequeue();

                if (currNum % 2 == 0)
                {
                    queue.Enqueue(currNum);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
