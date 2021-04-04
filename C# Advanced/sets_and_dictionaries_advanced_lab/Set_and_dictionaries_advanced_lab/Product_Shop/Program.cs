using System;
using System.Collections.Generic;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<string, Dictionary<string, double>> shopInformation = new SortedDictionary<string, Dictionary<string, double>>();

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string productName = input[1];
                double productPrice = double.Parse(input[2]);

                if (!shopInformation.ContainsKey(shopName))
                {
                    shopInformation.Add(shopName, new Dictionary<string, double>());
                }

                if (!shopInformation[shopName].ContainsKey(productName))
                {
                    shopInformation[shopName].Add(productName, productPrice);
                }

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in shopInformation)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
