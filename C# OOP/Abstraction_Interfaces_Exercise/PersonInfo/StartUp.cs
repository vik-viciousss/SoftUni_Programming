using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyersByName = new Dictionary<string, IBuyer>();

            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string name = parts[0];
                int age = int.Parse(parts[1]);

                if (parts.Length == 3)
                {
                    string group = parts[2];

                    buyersByName[name] = new Rebel(name, age, group);
                }
                else
                {
                    string id = parts[2];
                    string birthdate = parts[3];

                    buyersByName[name] = new Citizen(name, age, id, birthdate);
                }
            }


            while (true)
            {
                string buyerName = Console.ReadLine();
                
                if (buyerName == "End")
                {
                    break;
                }

                if (!buyersByName.ContainsKey(buyerName))
                {
                    continue;
                }
                else
                {
                    IBuyer buyer = buyersByName[buyerName];
                    buyer.BuyFood();
                }
            }

            int foodCount = buyersByName.Values.Sum(b => b.Food);

            Console.WriteLine(foodCount);




            // PROBLEM FIVE
            //List<IBirthable> birthables = new List<IBirthable>();

            //while (true)
            //{
            //    string line = Console.ReadLine();

            //    if (line == "End")
            //    {
            //        break;
            //    }

            //    string[] parts = line.Split();
            //    string type = parts[0];

            //    if (type == nameof(Citizen))
            //    {
            //        string name = parts[1];
            //        int age = int.Parse(parts[2]);
            //        string id = parts[3];
            //        string birthdate = parts[4];

            //        birthables.Add(new Citizen(name, age, id, birthdate));
            //    }
            //    else if (type == nameof(Pet))
            //    {
            //        string name = parts[1];
            //        string birthdate = parts[2];

            //        birthables.Add(new Pet(name, birthdate));
            //    }
            //}

            //string filterYear = Console.ReadLine();

            //var filteredBirthdables = birthables.Where(b => b.Birthdate.Split('/').Last() == filterYear);

            //foreach (var item in filteredBirthdables)
            //{
            //    Console.WriteLine(item.Birthdate);
            //}




            // PROBLEM TWO
            //List<IIdentifiable> identifiables = new List<IIdentifiable>();

            //while (true)
            //{
            //    string line = Console.ReadLine();

            //    if (line == "End")
            //    {
            //        break;
            //    }

            //    string[] parts = line.Split();

            //    if (parts.Length == 3)
            //    {
            //        string name = parts[0];
            //        int age = int.Parse(parts[1]);
            //        string id = parts[2];

            //        identifiables.Add(new Citizen(name, age, id));
            //    }
            //    else
            //    {
            //        string model = parts[0];
            //        string id = parts[1];

            //        identifiables.Add(new Robot(id, model));
            //    }
            //}

            //string filter = Console.ReadLine();

            //var filtered = identifiables.Where(i => i.Id.EndsWith(filter)).ToList();

            //foreach (var item in filtered)
            //{
            //    Console.WriteLine(item.Id);
            //}
        }
    }
}
