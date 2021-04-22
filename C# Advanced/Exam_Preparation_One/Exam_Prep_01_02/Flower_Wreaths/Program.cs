using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>();

            int[] liliesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < liliesInput.Length; i++)
            {
                lilies.Push(liliesInput[i]);
            }

            Queue<int> roses = new Queue<int>();

            int[] rosesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < rosesInput.Length; i++)
            {
                roses.Enqueue(rosesInput[i]);
            }

            int wreaths = 0;
            int flowersLeft = 0;

            while (lilies.Any() && roses.Any())
            {
                int currLilies = lilies.Peek();
                int currRoses = roses.Peek();

                if (currLilies + currRoses == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currLilies + currRoses > 15)
                {
                    while (true)
                    {
                        currLilies -= 2;

                        if (currLilies + currRoses == 15)
                        {
                            wreaths++;
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                        else if (currLilies + currRoses < 15)
                        {
                            flowersLeft += currLilies + currRoses;
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }

                }
                else
                {
                    flowersLeft += currLilies + currRoses;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            while (flowersLeft >= 15)
            {
                flowersLeft -= 15;
                wreaths++;
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
