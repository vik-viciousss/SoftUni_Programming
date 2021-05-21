using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProduct();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var line = Console.ReadLine();

            while (line != "END")
            {
                var parts = line.Split();

                var personName = parts[0];
                var productName = parts[1];

                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> ReadProduct()
        {
            var result = new Dictionary<string, Product>();

            var parts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var productData = part.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = productData[0];
                var cost = decimal.Parse(productData[1]);

                result[name] = new Product(name, cost);
            }

            return result;
        }

        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();

            var parts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var personData = part.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }
    }
}
