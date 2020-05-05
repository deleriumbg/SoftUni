using System;

namespace Dwarf_Presents
{
    class Program
    {
        static void Main(string[] args)
        {
            int dwarfsCount = int.Parse(Console.ReadLine());
            int totalMoney = int.Parse(Console.ReadLine());

            double presentSum = 0;
            for (int i = 0; i < dwarfsCount; i++)
            {
                string present = Console.ReadLine();
                switch (present)
                {
                    case "sand clock":
                        presentSum += 2.20;
                        break;
                    case "magnet":
                        presentSum += 1.50;
                        break;
                    case "cup":
                        presentSum += 5;
                        break;
                    case "t-shirt":
                        presentSum += 10;
                        break;
                }
            }
            if (totalMoney >= presentSum)
            {
                Console.WriteLine($"Santa Claus has {totalMoney - presentSum:f2} more leva left!");
            }
            else
            {
                Console.WriteLine($"Santa Claus will need {presentSum - totalMoney:f2} more leva.");
            }
        }
    }
}
