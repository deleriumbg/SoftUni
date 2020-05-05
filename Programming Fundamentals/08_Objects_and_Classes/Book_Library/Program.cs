using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<Book> books = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                Book book = new Book();
                List<string> input = Console.ReadLine().Split(' ').ToList();
                book.Title = input[0];
                book.Author = input[1];
                book.Publisher = input[2];
                book.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                book.ISBN = input[4];
                book.Price = double.Parse(input[5]);
                books.Add(book);
            }
            Library library = new Library();
            library.Name = "MyLibrary";
            library.Books = books;

            Dictionary<string, double> authorPrice = new Dictionary<string, double>();
            foreach (var book in library.Books)
            {
                if (authorPrice.ContainsKey(book.Author) == false)
                {
                    authorPrice.Add(book.Author, book.Price);
                }
                else
                {
                    authorPrice[book.Author] += book.Price;
                }
            }

            foreach (var book in authorPrice.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{book.Key} -> {book.Value:f2}");
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
