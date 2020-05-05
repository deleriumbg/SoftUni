using System;

namespace Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            switch (dayType)
            {
                case "Weekday":
                    if (age < 0 || age > 123)
                    {
                        price = 0;
                    }
                    else if (age >= 0 && age <= 18)
                    {
                        price = 12;
                    }
                    else if (age <= 64)
                    {
                        price = 18;
                    }
                    else if (age <= 122)
                    {
                        price = 12;
                    }
                    break;
                case "Weekend":
                    if (age < 0 || age > 123)
                    {
                        price = 0;
                    }
                    else if (age >= 0 && age <= 18)
                    {
                        price = 15;
                    }
                    else if (age <= 64)
                    {
                        price = 20;
                    }
                    else if (age <= 122)
                    {
                        price = 15;
                    }
                    break;
                case "Holiday":
                    if (age < 0 || age > 123)
                    {
                        price = 0;
                    }
                    else if (age >= 0 && age <= 18)
                    {
                        price = 5;
                    }
                    else if (age <= 64)
                    {
                        price = 12;
                    }
                    else if (age <= 122)
                    {
                        price = 10;
                    }
                    break;
            }
            if (price != 0)
            {
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
