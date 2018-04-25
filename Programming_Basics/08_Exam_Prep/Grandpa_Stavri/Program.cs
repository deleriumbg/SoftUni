using System;

namespace Grandpa_Stavri
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalLiters = 0;
            double averageGradus = 0;
            for (int i = 0; i < days; i++)
            {
                double rakia = double.Parse(Console.ReadLine());
                double gradus = double.Parse(Console.ReadLine());
                totalLiters += rakia;
                averageGradus += rakia * gradus;
            }
            Console.WriteLine($"Liter: {totalLiters:f2}\r\nDegrees: {averageGradus / totalLiters:f2}");
            if (averageGradus / totalLiters > 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
            else if (averageGradus / totalLiters >= 38 && averageGradus / totalLiters <= 42)
            {
                Console.WriteLine("Super!");
            }
            else
            {
                Console.WriteLine("Not good, you should baking!");
            }
        }
    }
}
