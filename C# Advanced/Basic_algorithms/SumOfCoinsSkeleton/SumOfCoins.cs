using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine()
            .Split(new string[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToArray();
        int targetSum = Console.ReadLine()
            .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .Last();

        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

        try
        {
            selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception exception)
        {

            Console.WriteLine("Error");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sortedCoins = coins.OrderByDescending(x => x).ToArray();


        //Dictionary<int, int> chosenCoins = new Dictionary<int, int>();

        //var currentSum = 0;
        //var coinIndex = 0;

        //while (currentSum != targetSum && coinIndex < sortedCoins.Length)
        //{
        //    var currentCoinValue = sortedCoins[coinIndex];

        //    var remainingSum = targetSum - currentSum;

        //    var numberOfCoinsToTake = remainingSum / currentCoinValue;

        //    if (numberOfCoinsToTake > 0)
        //    {
        //        chosenCoins.Add(currentCoinValue, numberOfCoinsToTake);
        //        currentSum += currentCoinValue * numberOfCoinsToTake;
        //    }

        //    coinIndex++;
        //}

        //if (currentSum != targetSum)
        //{
        //    throw new InvalidOperationException("Error");
        //}

        //return chosenCoins;

        Dictionary<int, int> result = new Dictionary<int, int>();

        var currentTarget = targetSum;
        int sum = 0;

        for (int i = 0; i < sortedCoins.Count(); i++)
        {
            int coinCount = currentTarget / sortedCoins[i];

            if (coinCount > 0)
            {
                result.Add(sortedCoins[i], coinCount);

                int tempSum = coinCount * sortedCoins[i];
                sum += tempSum;

                currentTarget = currentTarget - tempSum;
            }

            if (sum == targetSum)
            {
                return result;
            }
        }

        throw new Exception();
    }
}