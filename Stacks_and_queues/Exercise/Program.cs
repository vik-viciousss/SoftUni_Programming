using System;
using System.Collections.Generic;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> books = new Stack<string>();
            books.Push("Pinokio");
            books.Push("War and peace");
            books.Push("Alhimikyt");

            //izkarva nai-gorniq element ot stacka i go vrushta na konzolata:
            Console.WriteLine(books.Pop());

            //samo pokazva nai-gorniq element bez da go izkarva ot stacka:
            Console.WriteLine(books.Peek());



        }
    }
}
