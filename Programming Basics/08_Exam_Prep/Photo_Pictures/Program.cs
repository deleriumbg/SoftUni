using System;

namespace Photo_Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int photosCount = int.Parse(Console.ReadLine());
            string photoType = Console.ReadLine();
            string orderType = Console.ReadLine();
            double sum = 0;

            switch (photoType)
            {
                case "9X13":
                    sum = photosCount * 0.16;
                    if (photosCount >= 50)
                    {
                        sum *= 0.95;
                    }
                    break;
                case "10X15":
                    sum = photosCount * 0.16;
                    if (photosCount >= 80)
                    {
                        sum *= 0.97;
                    }
                    break;
                case "13X18":
                    sum = photosCount * 0.38;
                    if (photosCount >= 50 && photosCount <= 100)
                    {
                        sum *= 0.97;
                    }
                    else if (photosCount > 100)
                    {
                        sum *= 0.95;
                    }
                    break;
                case "20X30":
                    sum = photosCount * 2.9;
                    if (photosCount >= 10 && photosCount <= 50)
                    {
                        sum *= 0.93;
                    }
                    else if (photosCount > 50)
                    {
                        sum *= 0.91;
                    }
                    break;
            }
            if (orderType == "online")
            {
                sum *= 0.98;
            }
            Console.WriteLine($"{sum:f2}BGN");
        }
    }
}
