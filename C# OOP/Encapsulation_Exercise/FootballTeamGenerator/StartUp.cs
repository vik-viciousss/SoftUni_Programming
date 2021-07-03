using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string teamName = tokens[1];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            try
                            {
                                Team newTeam = new Team(teamName);
                                teams.Add(newTeam);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "Add":

                            Team current = teams.Where(x => x.Name == teamName).FirstOrDefault();

                            if (current == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                string playerName = tokens[2];
                                int endurance = int.Parse(tokens[3]);
                                int sprint = int.Parse(tokens[4]);
                                int dribble = int.Parse(tokens[5]);
                                int passing = int.Parse(tokens[6]);
                                int shooting = int.Parse(tokens[7]);

                                try
                                {
                                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                    current.AddPlayer(player);
                                }
                                catch (ArgumentException e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }
                            break;
                        case "Remove":

                            string playerToRemove = tokens[2];

                            Team currentTeam = teams.Where(x => x.Name == teamName).First();

                            try
                            {
                                currentTeam.RemovePlayer(playerToRemove);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "Rating":

                            Team team = teams.FirstOrDefault(x => x.Name == teamName);

                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }

                            Console.WriteLine($"{teamName} - {team.AverageRating}");
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }



            //var cmdArgs = Console.ReadLine().Split(";");

            ////Dictionary<string, Team> teamsByName = new Dictionary<string, Team>();

            //List<Team> teams = new List<Team>();

            //while (cmdArgs[0] != "END")
            //{
            //    string command = cmdArgs[0];
            //    string teamName = cmdArgs[1];

            //    try
            //    {
            //        if (command == "Team")
            //        {
            //            try
            //            {
            //                Team team = new Team(teamName);
            //                teams.Add(team);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }
            //        else if (command == "Add")
            //        {
            //            //if (!teamsByName.ContainsKey(teamName))
            //            //{
            //            //    Console.WriteLine($"Team {teamName} does not exist.");
            //            //    continue;
            //            //}

            //            Team current = teams.Where(x => x.Name == teamName).FirstOrDefault();

            //            if (current == null)
            //            {
            //                Console.WriteLine($"Team {teamName} does not exist.");
            //                continue;
            //            }

            //            string playerName = cmdArgs[2];
            //            int endurance = int.Parse(cmdArgs[3]);
            //            int sprint = int.Parse(cmdArgs[4]);
            //            int dribble = int.Parse(cmdArgs[5]);
            //            int passing = int.Parse(cmdArgs[6]);
            //            int shooting = int.Parse(cmdArgs[7]);

            //            try
            //            {
            //                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            //                current.AddPlayer(player);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }

            //        }
            //        else if (command == "Remove")
            //        {
            //            var playerName = cmdArgs[2];

            //            Team currentTeam = teams.Where(x => x.Name == teamName).First();

            //            try
            //            {
            //                currentTeam.RemovePlayer(playerName);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //            }
            //        }
            //        else if (command == "Rating")
            //        {
            //            //if (!teamsByName.ContainsKey(teamName))
            //            //{
            //            //    Console.WriteLine($"Team {teamName} does not exist.");
            //            //    continue;
            //            //}

            //            //var team = teamsByName[teamName];

            //            //Team team = teamsByName.Values.ToList().FirstOrDefault(x => x.Name == teamName);
            //            Team team = teams.FirstOrDefault(x => x.Name == teamName);

            //            if (team == null)
            //            {
            //                Console.WriteLine($"Team {teamName} does not exist.");
            //                continue;
            //            }

            //            Console.WriteLine($"{teamName} - {team.AverageRating}");
            //        }
            //    }
            //    catch (Exception)
            //    {

            //    }

            //    cmdArgs = Console.ReadLine().Split(";");
            //}
        }
    }
}
