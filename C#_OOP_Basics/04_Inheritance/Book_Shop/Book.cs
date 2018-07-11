using System;
using System.Text;

public class Book
{
    private const int MIN_TITLE_LENGTH = 3;
    private string author;
    private string title;
    private decimal price;

    protected string Author
    {
        get { return author; }
        set
        {
            string[] fullName = value.Split();
            if (fullName.Length == 2 && char.IsDigit(fullName[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length < MIN_TITLE_LENGTH)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");
        return result.ToString().TrimEnd();
    }
}
