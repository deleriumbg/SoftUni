using System;

public class Validator
{
    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }

    public static void ValidateMoney(decimal money)
    {
        if (money < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
    }
}
