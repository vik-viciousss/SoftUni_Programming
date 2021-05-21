using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cmdArgs = Console.ReadLine().Split(";");

            var teamsByName = new Dictionary<string, Team>();

            while (cmdArgs[0] != "END")
            {
                if (cmdArgs[0] == "Team")
                {
                    var teamName = cmdArgs[1];

                    try
                    {
                        var team = new Team(teamName);
                        teamsByName.Add(teamName, team);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (cmdArgs[0] == "Add")
                {
                    var teamName = cmdArgs[1];

                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    var playerName = cmdArgs[2];
                    var endurance = int.Parse(cmdArgs[3]);
                    var sprint = int.Parse(cmdArgs[4]);
                    var dribble = int.Parse(cmdArgs[5]);
                    var passing = int.Parse(cmdArgs[6]);
                    var shooting = int.Parse(cmdArgs[7]);

                    try
                    {
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teamsByName[teamName].AddPlayer(player);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (cmdArgs[0] == "Remove")
                {
                    var teamName = cmdArgs[1];
                    var playerName = cmdArgs[2];

                    try
                    {
                        teamsByName[teamName].RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (cmdArgs[0] == "Rating")
                {
                    var teamName = cmdArgs[1];

                    if (!teamsByName.ContainsKey(teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    var team = teamsByName[teamName];

                    Console.WriteLine($"{teamName} - {team.AverageRating}");
                }

                cmdArgs = Console.ReadLine().Split(";");
            }
        }
    }
}
