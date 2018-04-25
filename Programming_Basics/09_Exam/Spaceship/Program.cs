using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double astonautHeight = double.Parse(Console.ReadLine());

            double spacecraftVolume = width * length * height;
            double roomVolume = (astonautHeight + 0.40) * 2 * 2;
            double astronauts = Math.Floor(spacecraftVolume / roomVolume);
            if (astronauts < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (astronauts >= 3 && astronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {astronauts} astronauts.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
