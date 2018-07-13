using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string number)
    {
        if (number.Any(x => !char.IsDigit(x)))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Calling... {number}";
    }

    public string Browse(string website)
    {
        if (website.Any(char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {website}!";
    }
}
