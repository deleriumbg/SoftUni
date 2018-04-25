using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            double whole = Math.Floor(input);
            double cents = Math.Round((input - whole) * 100);
            int counter = 0;
            while (whole > 0)
            {
                if (whole >= 2)
                {
                    counter++;
                    whole -= 2;
                }
                else if (whole < 2 && whole >= 1)
                {
                    counter++;
                    whole -= 1;
                }
            }

            while (cents > 0)
            {
                if (cents >= 50)
                {
                    counter++;
                    cents -= 50;
                }
                else if (cents < 50 && cents >= 20)
                {
                    counter++;
                    cents -= 20;
                }
                else if (cents < 20 && cents >= 10)
                {
                    counter++;
                    cents -= 10;
                }
                else if (cents < 10 && cents >= 5)
                {
                    counter++;
                    cents -= 5;
                }
                else if (cents < 5 && cents >= 2)
                {
                    counter++;
                    cents -= 2;
                }
                else if (cents < 2 && cents >= 1)
                {
                    counter++;
                    cents -= 1;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
