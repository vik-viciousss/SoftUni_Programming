using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }



        }
    }
}
