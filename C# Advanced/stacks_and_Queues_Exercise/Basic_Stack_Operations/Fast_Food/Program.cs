using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                ordersQueue.Enqueue(orders[i]);
            }

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Any())
            {
                int currOrder = ordersQueue.Peek();

                if (currOrder <= foodQuantity)
                {
                    foodQuantity -= currOrder;
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Any())
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", ordersQueue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
