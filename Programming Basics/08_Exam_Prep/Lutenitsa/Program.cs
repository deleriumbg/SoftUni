using System;

namespace Lutenitsa
{
    class Program
    {
        static void Main(string[] args)
        {
            double tomatoes = double.Parse(Console.ReadLine());
            int cassettes = int.Parse(Console.ReadLine());
            int jars = int.Parse(Console.ReadLine());

            double liutenitsa = tomatoes / 5;
            double filledJars = liutenitsa / 0.535;
            double filledCassettes = filledJars / jars;

            Console.WriteLine($"Total lutenica: {Math.Floor(liutenitsa)} kilograms.");
            if (filledCassettes > cassettes)
            {
                Console.WriteLine($"{Math.Floor(filledCassettes - cassettes)} boxes left.\r\n{Math.Floor(filledJars - (jars * cassettes))} jars left.");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(cassettes - filledCassettes)} more boxes needed.\r\n{Math.Floor((jars * cassettes) - filledJars)} more jars needed.");
            }
        }
    }
}
