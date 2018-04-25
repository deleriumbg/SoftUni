using System;

namespace Thea_the_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPictures = long.Parse(Console.ReadLine());
            long filterTimePerPicSeconds = long.Parse(Console.ReadLine());
            long percentageGoodPic = long.Parse(Console.ReadLine());
            long uploadTimePerFilteredPicSeconds = long.Parse(Console.ReadLine());

            long filterTime = numberOfPictures * filterTimePerPicSeconds;
            long filteredPictures = (long)Math.Ceiling(numberOfPictures * percentageGoodPic / 100d);
            long uploadTime = filteredPictures * uploadTimePerFilteredPicSeconds;
            long totalTime = filterTime + uploadTime;

            TimeSpan time = TimeSpan.FromSeconds(totalTime);
            string result = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(result);
        }
    }
}
