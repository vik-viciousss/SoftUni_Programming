using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string[] authors = new string[] { "John" };

            //Book[] books = new Book[]
            //{
            //    new Book("Gone", 1879, authors),
            //    new Book("Not gone", 1879, authors)
            //};

            //Library<Book> myLibrary = new Library<Book>(books);

            //foreach (var book in myLibrary)
            //{
            //    Console.WriteLine(book.Title);
            //}

            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            //Library libraryOne = new Library();
            //Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            //foreach (var book in libraryTwo)
            //{
            //    Console.WriteLine(book);
            //}

            Library library = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
        }
    }
}
