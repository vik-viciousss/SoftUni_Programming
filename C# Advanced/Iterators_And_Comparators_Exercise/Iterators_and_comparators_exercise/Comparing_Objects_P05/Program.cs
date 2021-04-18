using System;
using System.Collections.Generic;

namespace Comparing_Objects_P05
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();

            List<Person> people = new List<Person>();

            while (inputData[0] != "END")
            {
                string name = inputData[0];
                int age = int.Parse(inputData[1]);
                string town = inputData[2];

                Person currPerson = new Person(name, age, town);
                people.Add(currPerson);

                inputData = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine());

            Person person = people[n - 1];

            int equalCount = 0;
            int notEqualCount = 0;

            foreach (var human in people)
            {
                int result = person.CompareTo(human);

                if (result != 0)
                {
                    notEqualCount++;
                }
                else
                {
                    equalCount++;
                }
            }

            if (equalCount <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
            }
        }
    }
}
