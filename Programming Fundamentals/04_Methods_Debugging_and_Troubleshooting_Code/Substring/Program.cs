using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int substringLength = int.Parse(Console.ReadLine()) + 1;

        const char search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == search)
            {
                hasMatch = true;

                if (i + substringLength > text.Length)
                {
                    Console.WriteLine(text.Substring(i));
                }
                else
                {
                    Console.WriteLine(text.Substring(i, substringLength));
                }
                i += substringLength - 1;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
