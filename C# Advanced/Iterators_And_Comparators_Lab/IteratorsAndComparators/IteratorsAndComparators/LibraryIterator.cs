using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset(); // to set the index to -1;
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            this.currentIndex++;

            return this.currentIndex < books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}