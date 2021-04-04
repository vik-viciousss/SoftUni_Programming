using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> names = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!names.ContainsKey(continent))
                {
                    names.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!names[continent].ContainsKey(country))
                {
                    names[continent].Add(country, new List<string>());
                }

                names[continent][country].Add(city);
            }

            foreach (var continent in names)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"{country.Key} -> ");

                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
