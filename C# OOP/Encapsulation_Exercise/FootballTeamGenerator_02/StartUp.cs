using System;
using System.Collections.Generic;

namespace FootballTeamGenerator_02
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var teamsByName = new Dictionary<string, Team>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] command = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Team")
                {
                    string teamName = command[1];

                    Team team = new Team(teamName);
                    teamsByName.Add(teamName, team);
                }
                else if (command[0] == "Add")
                {
                    string teamName = command[1];
                    string playerName = command[2];
                    int endurance = int.Parse(command[3]);
                    int sprint = int.Parse(command[4]);
                    int dribble = int.Parse(command[5]);
                    int passing = int.Parse(command[6]);
                    int shooting = int.Parse(command[7]);

                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    teamsByName[teamName].AddPlayer(player);
                }
                else if (command[0] == "Remove")
                {
                    string teamName = command[1];
                    string playerName = command[2];

                    try
                    {
                        teamsByName[teamName].RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command[0] == "Rating")
                {
                    var teamName = command[1];

                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    var team = teamsByName[teamName];

                    Console.WriteLine($"{teamName} - {team.AverageRating}");
                }

                line = Console.ReadLine();
            }
        }
    }
}
