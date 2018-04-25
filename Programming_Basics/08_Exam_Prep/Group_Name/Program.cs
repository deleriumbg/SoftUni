using System;

namespace Group_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            char fourth = char.Parse(Console.ReadLine());
            int fifth = int.Parse(Console.ReadLine());
            int counter = 0;

            for (char i = 'A'; i <= first; i++)
            {
                for (char j = 'a'; j <= second; j++)
                {
                    for (char k = 'a'; k <= third; k++)
                    {
                        for (char m = 'a'; m <= fourth; m++)
                        {
                            for (int n = 0; n <= fifth; n++)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter - 1);
        }
    }
}
