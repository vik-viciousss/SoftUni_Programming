using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Box_Of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();
            //List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                //int input = int.Parse(Console.ReadLine());
                double input = double.Parse(Console.ReadLine());

                Box<double> currBox = new Box<double>(input);

                boxes.Add(currBox);
            }

            double value = double.Parse(Console.ReadLine());

            Box<double> comparableBox = new Box<double>(value);

            int count = GetGreaterThanCount<double>(boxes, comparableBox);

            Console.WriteLine(count);

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //StartUp.Swap(boxes, indexes[0], indexes[1]);

            //foreach (var box in boxes)
            //{
            //    Console.WriteLine(box);
            //}
        }

        private static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in boxes)
            {
                if (item.Value.CompareTo(box.Value) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static void Swap<T>(List<Box<T>> boxes, int indexOne, int indexTwo)
            where T : IComparable
        {
            Box<T> temp = boxes[indexOne];
            boxes[indexOne] = boxes[indexTwo];
            boxes[indexTwo] = temp;
        }
    }
}
