using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine().Split();
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";
            List<string> townRaw = firstTupleData.ToList().Skip(3).ToList();

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, firstTupleData[2], string.Join(" ", townRaw));

            string[] secondTupleData = Console.ReadLine().Split();
            bool isDrunk = DrunkOrNot(secondTupleData[2]);

            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(secondTupleData[0], int.Parse(secondTupleData[1]), isDrunk);

            string[] thirdTupleData = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(thirdTupleData[0], double.Parse(thirdTupleData[1]), thirdTupleData[2]);


            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }

        private static bool DrunkOrNot(string stringy)
        {
            if (stringy == "drunk")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
