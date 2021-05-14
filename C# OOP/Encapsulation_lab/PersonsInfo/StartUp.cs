using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            Team team = new Team("SoftUni");
            
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();


                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }

            //var parcentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => team.AddPlayer(p));

            Console.WriteLine($"First team: {team.FirstTeam.Count}");
            Console.WriteLine($"Reserve team: {team.ReserveTeam.Count}");


        }
    }
}
