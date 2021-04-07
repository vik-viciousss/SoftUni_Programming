using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                string[] allClothes = input.Skip(1).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var currCloth in allClothes)
                {
                    if (!wardrobe[color].ContainsKey(currCloth))
                    {
                        wardrobe[color].Add(currCloth, 0);
                    }

                    wardrobe[color][currCloth]++;
                }
            }

            string[] clothesToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colorToFind = clothesToFind[0];
            string clothToFind = clothesToFind[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == colorToFind && cloth.Key == clothToFind)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
