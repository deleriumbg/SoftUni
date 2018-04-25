using System;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallLength = double.Parse(Console.ReadLine());
            double hallWidth = double.Parse(Console.ReadLine());
            double wardrobeSide = double.Parse(Console.ReadLine());

            double hallArea = (hallLength * 100) * (hallWidth * 100);
            double wardrobeSize = (wardrobeSide * 100) * (wardrobeSide * 100);
            double benchSize = hallArea / 10;
            double freeSpace = hallArea - (wardrobeSize + benchSize);
            double dancers = Math.Floor(freeSpace / 7040);
            Console.WriteLine(dancers);
        }
    }
}
