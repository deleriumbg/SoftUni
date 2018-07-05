using System;
using System.Globalization;

public class DateModifier
{
    public string FirstDate { get; set; }
    public string SecondDate { get; set; }

    public DateModifier(string firstDate, string secondDate)
    {
        FirstDate = firstDate;
        SecondDate = secondDate;
    }

    public void CalculateDifference(string firstStr, string secondStr)
    {
        DateTime firstDate = DateTime.ParseExact(firstStr, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(secondStr, "yyyy MM dd", CultureInfo.InvariantCulture);
        int daysDifference = (secondDate.Date - firstDate.Date).Days;
        Console.WriteLine(Math.Abs(daysDifference));
    }
}
