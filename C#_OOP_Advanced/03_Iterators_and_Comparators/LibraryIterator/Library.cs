using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public List<Book> Books { get; set; }

    public Library(params Book[] books)
    {
        Books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current => this.books[this.currentIndex];


        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
