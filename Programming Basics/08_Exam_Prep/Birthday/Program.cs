using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double volume = length * width * height * 0.001;
            double percentage = percent * 0.01;
            double liters = volume * (1 - percentage);
            Console.WriteLine($"{liters:f3}");
        }
    }
}
