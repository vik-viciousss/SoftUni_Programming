using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(inputSongs);

            bool isEmpty = false;

            while (songsQueue.Any())
            {
                string commands = Console.ReadLine();
                string[] currCommand = commands.Split();

                if (currCommand[0] == "Play")
                {
                    if (songsQueue.Count < 1)
                    {
                        Console.WriteLine("No more songs!");
                        break;
                    }
                    else
                    {
                        songsQueue.Dequeue();

                        if (songsQueue.Count < 1)
                        {
                            Console.WriteLine("No more songs!");
                            break;
                        }
                    }
                }
                else if (currCommand[0] == "Add")
                {
                    string songName = commands.Substring(4);

                    if (songsQueue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(songName);
                    }
                }
                else if (currCommand[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

        }
    }
}
