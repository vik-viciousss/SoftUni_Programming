using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> record = new Dictionary<string, Dictionary<string, int>>();

            string[] tokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0] != "Log out")
            {
                if (tokens[0] == "New follower")
                {
                    string username = tokens[1];

                    if (!record.ContainsKey(username))
                    {
                        record.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", 0 },
                            { "comments", 0 }
                        });
                    }
                }
                else if (tokens[0] == "Like")
                {
                    string username = tokens[1];
                    int count = int.Parse(tokens[2]);

                    if (!record.ContainsKey(username))
                    {
                        record.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", count },
                            { "comments", 0 }
                        });
                    }
                    else
                    {
                        record[username]["likes"] += count;
                    }

                }
                else if (tokens[0] == "Comment")
                {
                    string username = tokens[1];

                    if (!record.ContainsKey(username))
                    {
                        record.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", 0 },
                            { "comments", 1 }
                        });
                    }
                    else
                    {
                        record[username]["comments"]++;
                    }
                }
                else if (tokens[0] == "Blocked")
                {
                    string username = tokens[1];

                    if (record.ContainsKey(username))
                    {
                        record.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }

                tokens = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            int followersCount = record.Count;

            Dictionary<string, int> sorted = new Dictionary<string, int>();

            Console.WriteLine($"{followersCount} followers");

            foreach (var kvp in record)
            {
                int likesAndComments = 0;
                int likes = record[kvp.Key]["likes"];
                int comments = record[kvp.Key]["comments"];

                likesAndComments += likes + comments;

                sorted.Add(kvp.Key, likesAndComments);
            }

            sorted = sorted.OrderByDescending(v => v.Value).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
