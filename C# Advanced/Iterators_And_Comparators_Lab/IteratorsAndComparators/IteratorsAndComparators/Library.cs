using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book> 
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] books)
        {
            IComparer<Book> comparator = new BookComparator();
            this.books = new SortedSet<Book>(books, comparator);
        }

        public Library()
        {
            IComparer<Book> comparator = new BookComparator();
            this.books = new SortedSet<Book>(comparator);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);

            //foreach (var book in this.books)
            //{
            //    yield return book;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
