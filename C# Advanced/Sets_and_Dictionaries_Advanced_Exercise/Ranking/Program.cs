﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsData = new Dictionary<string, string>();

            string contestInput = Console.ReadLine();

            while (contestInput != "end of contests")
            {
                string[] contestData = contestInput.Split(":");
                contestsData.Add(contestData[0], contestData[1]);

                contestInput = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> usersSubmissions = new SortedDictionary<string, Dictionary<string, int>>();

            string submissionInput = Console.ReadLine();

            while (submissionInput != "end of submissions")
            {
                string[] submissionData = submissionInput.Split("=>");
                string contest = submissionData[0];
                string password = submissionData[1];
                string username = submissionData[2];
                int points = int.Parse(submissionData[3]);

                if (!contestsData.ContainsKey(contest) || contestsData[contest] != password)
                {
                    submissionInput = Console.ReadLine();
                    continue;
                }

                if (!usersSubmissions.ContainsKey(username))
                {
                    usersSubmissions.Add(username, new Dictionary<string, int>());
                }

                if (!usersSubmissions[username].ContainsKey(contest))
                {
                    usersSubmissions[username].Add(contest, points);
                }
                else
                {
                    int oldPoints = usersSubmissions[username][contest];

                    if (oldPoints < points)
                    {
                        usersSubmissions[username][contest] = points;
                    }
                }

                submissionInput = Console.ReadLine();
            }

            KeyValuePair<string, Dictionary<string, int>> bestCandidate = 
                usersSubmissions.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();

            int totalPoints = bestCandidate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in usersSubmissions)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
