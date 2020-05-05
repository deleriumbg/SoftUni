using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string faculcyNumber;

    public string FaculcyNumber
    {
        get { return faculcyNumber; }
        set
        {
            string pattern = "^[A-Za-z0-9]{5,10}$";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            faculcyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string faculcyNumber) : base(firstName, lastName)
    {
        FaculcyNumber = faculcyNumber;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString()).AppendLine($"Faculty number: {this.FaculcyNumber}");
        return result.ToString().TrimEnd();
    }
}
