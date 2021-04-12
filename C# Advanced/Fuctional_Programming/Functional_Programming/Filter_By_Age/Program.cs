using System;

namespace Filter_By_Age
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person();

                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);


            }

            string filter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string printFormat = Console.ReadLine();

            Func<Person, bool> condition = GetAgeCondition(filter, ageFilter);
            Func<Person, string> formatter = GetPrintFormat(printFormat);

            PrintPeople(people, condition, formatter);

        }
        static Func<Person, bool> GetAgeCondition(string filter, int ageFilter)
        {
            switch (filter)
            {
                case "younger":
                    return p => p.Age < ageFilter;
                case "older":
                    return p => p.Age >= ageFilter;
                default:
                    return null;
            }


        }

        static Func<Person, string> GetPrintFormat(string printFormat)
        {
            switch (printFormat)
            {
                case "name":
                    return p => $"{p.Name}";
                case "age":
                    return p => $"{p.Age}";
                case "name age":
                    return p => $"{p.Name} - {p.Age}";
                default:
                    return null;
            }
        }
        static void PrintPeople(Person[] people, Func<Person, bool> condition, Func<Person, string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }
    }
}
