using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string commandInput = Console.ReadLine();

            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (commandInput != "Statistics")
            {
                string[] commandData = commandInput.Split(" ");
                string vloggerName = commandData[0];
                string command = commandData[1];

                if (command == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string target = commandData[2];

                    if (app.ContainsKey(vloggerName) && app.ContainsKey(target) && vloggerName != target)
                    {
                        app[vloggerName]["following"].Add(target);
                        app[target]["followers"].Add(vloggerName);
                    }

                }

                commandInput = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDataApp =
                app.OrderByDescending(kvp => kvp.Value["followers"].Count)
                .ThenBy(kvp => kvp.Value["following"].Count).ToDictionary(k => k.Key, v => v.Value);

            int counter = 1;

            foreach (var vlogger in sortedDataApp)
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (vlogger.Value["followers"].Count > 0 && counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }
    }
}
