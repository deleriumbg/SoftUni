using System;

namespace Picture_in_the_Wall
{
    class Program
    {
        static void Main(string[] args)
        {
            int holeWidth = int.Parse(Console.ReadLine());
            int holeLength = int.Parse(Console.ReadLine());
            int pictureSide = int.Parse(Console.ReadLine());
            int pictureCount = int.Parse(Console.ReadLine());

            int holeArea = holeWidth * holeLength;
            int pictureArea = pictureSide * pictureSide;
            if (holeArea >= pictureArea * pictureCount)
            {
                Console.WriteLine($"The pictures fit in the hole. Hole area is {holeArea - (pictureArea * pictureCount)} bigger than pictures area.");
            }
            else
            {
                Console.WriteLine($"The pictures don't fit in the hole. Picture area is {(pictureArea * pictureCount) - holeArea} bigger than hole area.");
            }
        }
    }
}
