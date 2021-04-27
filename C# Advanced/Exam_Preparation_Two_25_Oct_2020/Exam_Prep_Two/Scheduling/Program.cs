using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] taskInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> tasks = new Stack<int>(taskInput);

            int[] threadInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> threads = new Queue<int>(threadInput);

            int taskToKill = int.Parse(Console.ReadLine());

            int currTask = tasks.Peek();
            int currThread = threads.Peek();

            while (currTask != taskToKill)
            {
                if (currThread >= currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }

                currTask = tasks.Peek();
                currThread = threads.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {currTask}");
                }
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
