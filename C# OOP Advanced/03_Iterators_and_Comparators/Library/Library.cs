using System;
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
        for (int i = 0; i < this.Books.Count; i++)
        {
            yield return this.Books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
